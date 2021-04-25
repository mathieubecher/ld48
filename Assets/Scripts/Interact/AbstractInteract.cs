using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteract : MonoBehaviour
{
    public bool set;
    public virtual bool CouldInteract(){return !set;}
    public virtual void Interact(){set = true;}
    
}
