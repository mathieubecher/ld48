using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightGestor : MonoBehaviour
{
    [SerializeField]private List<EnvironmentLight> _lights;

    private List<string> _tags;
    // Start is called before the first frame update
    void Start()
    {
        _tags = new List<string>();
        _tags.Add("_lightPosition2");
        _tags.Add("_lightPosition4");
        _lights = FindObjectsOfType<EnvironmentLight>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tag in _tags)
        {
            EnvironmentLight lightCandidate = null;
            foreach (var light in _lights)
            {
                if (light.lightId == tag)
                {
                    if (lightCandidate == null || ((lightCandidate.transform.position - transform.position).magnitude - lightCandidate.intensity >
                                           (light.transform.position - transform.position).magnitude - light.intensity))
                    {
                        lightCandidate = light;
                    }

                    light.isActive = false;
                }

                if(lightCandidate != null) lightCandidate.isActive = true;
                else
                    Shader.SetGlobalVector(tag, new Vector4(0.0f,0.0f,0.01f));
            }
        }
    }
}
