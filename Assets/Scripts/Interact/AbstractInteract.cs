using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteract : MonoBehaviour
{
    public bool set;
    public string info = "[Activate]";
    public virtual bool CouldInteract(Controller controller){return !set;}
    public virtual void Interact(){set = true;}

    public virtual void Reset()
    {
        
    }
    
}
