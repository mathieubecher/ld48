using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairInteract : AbstractInteract
{
    public Transform start;
    public Transform end;
    public Transform controller;
    public float speed;
    public CounterInteract counter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            if (Vector2.Dot((Vector2)(controller.position - end.position),(Vector2)(start.position - end.position)) > 0.0f)
            {
                Vector2 deltaPos = (end.position - start.position).normalized * speed * Time.deltaTime;
                controller.position += (Vector3)deltaPos;
            }
            else
            {
                controller.GetComponent<Rigidbody2D>().isKinematic = false;
                Controller c = FindObjectOfType<Controller>();
                if(c.IsAlive()) c.StartPlayer();
                counter.set = false;
                set = false;
                controller.GetComponent<Animator>().SetBool("Ladder", false);
            }
        }
    }

    public override bool CouldInteract()
    {
        return !counter.set && !set && counter.counter > 0;
    }

    public override void Interact()
    {
        counter.set = true;
        set = true;
        --counter.counter;
        controller = FindObjectOfType<Controller>().transform;
        FindObjectOfType<Controller>().StopPlayer();
        controller.GetComponent<Rigidbody2D>().isKinematic = true;
        controller.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        controller.GetComponent<Animator>().SetBool("Ladder", true);
        controller.transform.position = new Vector2(start.position.x, controller.transform.position.y);

    }
}
