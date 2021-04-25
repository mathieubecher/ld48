using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteract : MonoBehaviour
{
    [SerializeField] private int _counter = 1;

    public int counter
    {
        get => _counter;
        set { _counter = Math.Min(value, maxCharge); }
    }
    public int maxCharge = 3;

    public bool set;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
