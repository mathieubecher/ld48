using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D controller;
    public bool dir = true;
    [HideInInspector] public bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        controller = other.GetComponent<Rigidbody2D>();
        other.gameObject.transform.parent = transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger) return;
        controller = null;
        other.gameObject.transform.parent = null;
    }
}
