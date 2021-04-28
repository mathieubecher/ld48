using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystem : MonoBehaviour
{
    public CounterInteract counter;
    public Transform top;
    public Transform bottom;
    public float speed = 10.0f;
    [Header("Platform")]
    public ElevatorInteract leftPlatform;
    public ElevatorInteract rightPlatform;

    [HideInInspector] public bool set;
    public int used;
    public bool dir
    {
        get => used % 2 == 0;
    }

    private ElevatorInteract active;
    private bool _reset;
    // Start is called before the first frame update
    void Start()
    {
        rightPlatform.transform.position += (top.transform.position.y - bottom.transform.position.y) * Vector3.up;
        leftPlatform.elevator = this;
        rightPlatform.elevator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            if (Vector2.Dot((leftPlatform.transform.position - (used%2 == 1?top.position:bottom.position)),(used%2 == 0?1.0f:-1.0f) * (top.position - bottom.position)) > 0.0f)
            {
                Vector2 deltaPos = (top.position - bottom.position).normalized * speed * Time.deltaTime;
                leftPlatform.transform.position -= (used%2 == 0?1.0f:-1.0f) * (Vector3)deltaPos;
                rightPlatform.transform.position += (used%2 == 0?1.0f:-1.0f) * (Vector3)deltaPos;
            }
            else if(!_reset) StartCoroutine("InteractEnd");
            
        }
    }
    public bool CouldInteract(Controller controller)
    {
        return !set && counter.counter > 0 && !controller.stop;
    }

    public void Interact(ElevatorInteract _active)
    {
        if (!_active.controller.GetComponent<Controller>().OnGround()) return;
        _reset = false;
        active = _active;
        active.controller.transform.position =
            new Vector2(active.transform.position.x, active.controller.transform.position.y);
        active.controller.isKinematic = true;
        active.controller.velocity = Vector2.zero;
        active.controller.GetComponent<Controller>().StopPlayer();
        set = true;
        ++used;
        --counter.counter;
        StartCoroutine("InteractLaunch");


    }
    IEnumerator InteractLaunch() 
    {
        float realSpeed = speed;
        speed = 0.0f;
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < 10; ++i)
        {
            speed += realSpeed * 0.1f;
            yield return new WaitForSeconds(0.1f);
            
        }
    }
    IEnumerator InteractEnd()
    {
        _reset = true;
        float realSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(0.7f);
        counter.set = false;
        set = false;
        if (active.controller != null)
        {
            active.controller.isKinematic = false;
            active.controller.velocity = Vector2.zero;
            active.controller.GetComponent<Controller>().StartPlayer();
        }

        speed = realSpeed;
    }
}
