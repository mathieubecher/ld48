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
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private SpriteRenderer globe;
    
    private float _lightTimer = 0.0f;
    

    public float GetRemainingTime()
    {
        return energy.keys.Last().time - _lightTimer;
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
    
    [SerializeField] private bool _switchLight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch()
    {
        _launch = true;

    }
    public void Stop()
    {
        startEnergy = 1.0f;
        _launch = false;
        _lightTimer = (1 - startEnergy) * energy.keys.Last().time;

    }
    // Update is called once per frame
    void Update()
    {
        float energyCoeff = 1.0f;
        if (_launch)
        {
            _lightTimer += Time.deltaTime * (_switchLight?1.0f:0.1f); 
            energyCoeff = energy.Evaluate(_lightTimer);
        }
        
        if (_switchLight)
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
            FindObjectOfType<Controller>().Respawn(false);
        }
        
        timerText.text = GetRemainingTimeToText();
        if(globe.enabled)
            Shader.SetGlobalVector("_lightPosition1", new Vector4(transform.position.x, transform.position.y, intensity * energyCoeff));   
        else
            Shader.SetGlobalVector("_lightPosition1", new Vector4(transform.position.x, transform.position.y, 0.01f));
    }

    public void Switch()
    {
        _switchLight = !_switchLight;
        
    }

    public void UnPlug()
    {
        globe.enabled = false;
        _switchLight = false;
    }

    public void Plug()
    {
        globe.enabled = true;
    }
}
