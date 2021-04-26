using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnergyBarre : MonoBehaviour
{
    private ReloaderInteract _interact;
    [SerializeField] private GameObject barr;
    // Start is called before the first frame update
    void Start()
    {
        _interact = GetComponent<ReloaderInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        barr.transform.localScale = new Vector3(1,_interact.counter.counter,1);
    }
}
