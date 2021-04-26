using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBySpeed : MonoBehaviour
{
    public float radius = 1.0f;
    public PlatformInteract interact;
    public Platform platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interact.set)
            transform.Rotate(Vector3.forward, (platform.dir?1:-1) * interact.speed /( radius * (float)Math.PI * 2.0f) * Time.deltaTime * 360f);
        
    }
}
