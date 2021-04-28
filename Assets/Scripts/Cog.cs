using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cog : MonoBehaviour
{
    private bool _selection;
    private Controller _controller;
    public float energy = 10.0f; 
    [SerializeField] private TextMeshPro infosText;
    [SerializeField] private TextMeshPro energyText;
    [SerializeField] private TextMeshPro runEnergyText;

    public EnvironmentLight light;
    public bool endEnergy = false;

    private float maxEnergy;
    private float maxLight;
    // Start is called before the first frame update
    void Start()
    {
        maxEnergy = energy;
        maxLight = light.intensity;
        
        _controller = FindObjectOfType<Controller>();
        energy -= 1.0f;
    }

    void Update()
    {
        if (_selection) infosText.alpha += Time.deltaTime * 2;
        else infosText.alpha -= Time.deltaTime * 2;
        
        infosText.alpha = Math.Min(Math.Max(infosText.alpha, 0.0f), 1.0f);
        energyText.text = "Energy of Cog : " + ((int) Math.Floor(energy * 10.0f));
        
        runEnergyText.text = "Actual : " + (int)Math.Ceiling(_controller.getLight.startEnergy * 10.0f);

        light.intensity = 1.0f + (maxLight - 1.0f ) * (energy / maxEnergy); 
        endEnergy = (energy <= 0.0f);
    }

    public void AddTime(InputAction.CallbackContext context)
    {
        if (!_selection || !context.performed) return;
        UpdateTime(0.1f);
    }
    public void RemoveTime(InputAction.CallbackContext context)
    {
        if (!_selection || !context.performed) return;
        UpdateTime(-0.1f);
    }
    private void UpdateTime(float add)
    {
        if (add > 0.0f && energy >= add && _controller.getLight.startEnergy + add <= 1.0f )
        {
            energy -= add;
            _controller.getLight.startEnergy += add;
        }

        if (add < 0.0f && _controller.getLight.startEnergy >= -add)
        {
            energy -= add;
            _controller.getLight.startEnergy += add;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        _selection = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _selection = false;
    }
}
