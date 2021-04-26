using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    
    public Platform platform;
    public CounterInteract counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(platform.dir && counter.set)
            transform.eulerAngles = new Vector3(0.0f,0.0f,45f);
        else if(!platform.dir && counter.set)
            transform.eulerAngles = new Vector3(0.0f,0.0f,-45f);
        //Debug.Log(transform.rotation.z);
    }
}
