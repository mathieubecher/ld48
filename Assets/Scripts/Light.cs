using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private float intensity = 5.0f;
    [SerializeField] private AnimationCurve turnOff;
    [SerializeField] private AnimationCurve turnOn;
    [SerializeField] private AnimationCurve energy;
    [SerializeField] private AnimationCurve energyCost;
    [SerializeField] private AnimationCurve energyCostOff;
    private float _switchEnergyCostTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public SpriteRenderer globe;
    
    private float _lightTimer = 0.0f;
    

    public float GetRemainingTime()
    {
        return energy.keys.Last().time - _lightTimer;
    }

    public float GetRemainingTimePercent()
    {
        return GetRemainingTime() / energy.keys.Last().time;
    }
    public bool Charge(float cost)
    {
        if(cost > GetRemainingTimePercent()) 
            return false;

        _lightTimer += cost * energy.keys.Last().time;
        return true;
    }
    public bool CouldCharge(float cost)
    {
        return cost < GetRemainingTimePercent();
    }
    public string GetRemainingTimeToText()
    {
        int timer = (int)Math.Floor(GetRemainingTime());
        int seconds = Math.Max(timer % 60, 0);

        int minutes = timer / 60;
        string time = (minutes < 10?"0":"") + minutes + ":" + (seconds < 10?"0":"")+seconds;
        return time;
    }
    private float _startEnergy = 1.0f;

    public float startEnergy
    {
        get => _startEnergy;
        set
        { 
            _startEnergy = value;
            _lightTimer = (1 - startEnergy) * energy.keys.Last().time;
        }
    }

    private bool _launch = false;
    
    [SerializeField] public bool switchLight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch()
    {
        _launch = true;

    }
    public void Stop(float energyStart)
    {
        startEnergy = energyStart;
        _launch = false;
        _lightTimer = (1 - startEnergy) * energy.keys.Last().time;

    }

    [SerializeField] private float _debugEnergy = 0.0f;
    // Update is called once per frame
    void Update()
    {
        float energyCoeff = 1.0f;
        if (_launch)
        {
            if (switchLight && _switchEnergyCostTimer < energyCost.keys.Last().time)
                _switchEnergyCostTimer += Time.deltaTime;
            else if (!switchLight && _switchEnergyCostTimer > 0)
                _switchEnergyCostTimer -= Time.deltaTime;
            AnimationCurve cost = (switchLight) ? energyCost : energyCostOff;
            _debugEnergy = cost.Evaluate(_switchEnergyCostTimer);
            _lightTimer += Time.deltaTime * cost.Evaluate(_switchEnergyCostTimer);//(switchLight?1.0f:0.1f); 
            energyCoeff = energy.Evaluate(_lightTimer);
        }
        
        if (switchLight)
        {
            float time = Controller.TimeFromValue(turnOn, intensity) + Time.deltaTime;
            intensity = turnOn.Evaluate(time);
        }
        else
        {
            float time = Controller.TimeFromValue(turnOff, intensity) - Time.deltaTime;
            intensity = turnOff.Evaluate(time);
        }

        if (_lightTimer > energy.keys.Last().time)
        {
            FindObjectOfType<Controller>().Respawn(true);
        }
        
        timerText.text = GetRemainingTimeToText();
        if(globe.enabled)
            Shader.SetGlobalVector("_lightPosition1", new Vector4(transform.position.x, transform.position.y, intensity * energyCoeff));   
        else
            Shader.SetGlobalVector("_lightPosition1", new Vector4(transform.position.x, transform.position.y, 0.01f));
    }

    public void Switch()
    {
        switchLight = !switchLight;
        if (switchLight)
            _switchEnergyCostTimer = 0;

    }

    public void UnPlug()
    {
        globe.enabled = false;
        switchLight = false;
    }

    public void Plug()
    {
        globe.enabled = true;
    }
}
