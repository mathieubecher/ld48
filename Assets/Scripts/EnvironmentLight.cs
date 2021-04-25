using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnvironmentLight : MonoBehaviour
{
    public string lightId = "_lightPosition2";
    public float intensity = 15.0f;
    private float _lightTimer = 0.0f;
    public bool isActive = true;
    void Start()
    {
    }

    void Update()
    {
        
        _lightTimer += Time.deltaTime * UnityEngine.Random.value * 2.0f;
        if(isActive) Shader.SetGlobalVector(lightId, new Vector4(transform.position.x, transform.position.y, Math.Max(0.1f, intensity + (float)Math.Cos(_lightTimer) * 0.5f),0.0f));
    }
}
