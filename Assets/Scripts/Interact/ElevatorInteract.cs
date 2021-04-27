using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteract : AbstractInteract
{
    [HideInInspector] public Rigidbody2D controller;
    [HideInInspector] public ElevatorSystem elevator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool CouldInteract(Controller controller)
    {
        return elevator.CouldInteract(controller);
    }

    public override void Interact()
    {
        elevator.Interact(this);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        if (other.TryGetComponent<Controller>(out var c))
        {
            controller = c.GetComponent<Rigidbody2D>();
            c.gameObject.transform.parent = transform;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger) return;
        if (other.TryGetComponent<Controller>(out var c))
        {
            controller = null;
            other.gameObject.transform.parent = null;
        }
    }
}
