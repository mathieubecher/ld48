using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractLight : AbstractInteract
{
    public EnvironmentLight environmentLight;
    public SpriteRenderer sprite;
    private float _originalIntensity;
    private float _lightTimer;

    public AnimationCurve switchOn;
    // Start is called before the first frame update
    void Start()
    {
        _originalIntensity = environmentLight.intensity;
        if (!set) 
            environmentLight.intensity = 0.01f;
        else
        {
            _lightTimer = 100.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (set && _lightTimer < switchOn.keys.Last().time)
        {
            _lightTimer += Time.deltaTime;
            environmentLight.intensity = _originalIntensity * switchOn.Evaluate(_lightTimer);
        }
    }

    public override void Interact()
    {
        if (set) return;
        set = true;
        _lightTimer = 0;
        sprite.enabled = true;
        FindObjectOfType<Controller>().StartCoroutine("UnPlugLight");
    }

    public override bool CouldInteract(Controller controller)
    {
        return !set;
    }
}
