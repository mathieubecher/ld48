using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloaderInteract : AbstractInteract
{
    
    public CounterInteract counter;
    public float cost = 0.1f;

    public override bool CouldInteract()
    {
        
        return counter.counter < counter.maxCharge && FindObjectOfType<Light>().CouldCharge(cost);
    }

    public override void Interact()
    {
        if(FindObjectOfType<Light>().Charge(cost))
            ++counter.counter;
    }
}
