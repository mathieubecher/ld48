using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRowBySpeed : MonoBehaviour
{
    public float radius = 1.0f;
    
    public ElevatorSystem elevator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elevator.set)
            transform.Rotate(Vector3.forward, (elevator.dir?1:-1) * elevator.speed /( radius * (float)Math.PI * 2.0f) * Time.deltaTime * 360f);
        
    }
}
