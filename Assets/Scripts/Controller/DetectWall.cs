using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWall : MonoBehaviour
{
    private List<Collider2D> _contacts;
    public bool HitWall(){return (_contacts != null && _contacts.Count > 0);}

    void Awake()
    {
        _contacts = new List<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        _contacts.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger) return;
        _contacts.Remove(other);
    }
}
