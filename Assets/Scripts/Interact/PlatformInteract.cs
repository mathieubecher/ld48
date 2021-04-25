using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteract : AbstractInteract
{
    public Transform start;
    public Transform end;
    public float speed = 10.0f;
    private bool _dir = true;
    public bool kynematic = false;
    public bool elevator = false;
    private Platform _platform;
    
    public CounterInteract counter;
    void Start()
    {
        _platform = transform.parent.GetComponent<Platform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            if (Vector2.Dot((_platform.transform.position - (_dir?end.position:start.position)),(_dir?1.0f:-1.0f) * (start.position - end.position)) > 0.0f)
            {
                Vector2 deltaPos = (_dir?1.0f:-1.0f) * (end.position - start.position).normalized * speed * Time.deltaTime;
                _platform.transform.position += (Vector3)deltaPos;
            }
            else
            {
                counter.set = false;
                set = false;
                if (kynematic && _platform.controller != null)
                {
                    _platform.controller.isKinematic = false;
                    _platform.controller.velocity = Vector2.zero;
                    _platform.controller.GetComponent<Controller>().StartPlayer();
                }
                
                _dir = !_dir;
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
        if (kynematic && _platform.controller != null)
        {
            _platform.controller.isKinematic = true;
            _platform.controller.velocity = Vector2.zero;
            _platform.controller.GetComponent<Controller>().StopPlayer();
            
        }
        StartCoroutine("InteractLaunch");
        --counter.counter;

    }

    IEnumerator InteractLaunch() 
    {
        float realSpeed = speed;
        speed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 10; ++i)
        {
            speed += realSpeed * 0.1f;
            yield return new WaitForSeconds(0.1f);
            
        }
    }

    public override void Reset()
    {
        if (elevator && counter.counter > 0)
            _platform.transform.position = end.position;
    }
}
