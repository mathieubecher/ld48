using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLadder : MonoBehaviour
{
    public GameObject sprite;
    public CounterInteract counter;
    public StairInteract top;
    public List<SpriteRenderer> stairs;
    public List<Sprite> degradation;
    public int degradate = 0;
    private int _lastDegradate = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        stairs = new List<SpriteRenderer>();
        
        Vector3 startPos = transform.position;
        startPos.x = (float)Math.Floor(transform.position.x) + 0.5f; 
        startPos.y = (float)Math.Floor(transform.position.y) + 0.5f;
        startPos.z = 0.0f;
        for (int i = 0; i >= (top.end.position - top.start.position).y; --i)
        {
            GameObject stair = Instantiate(sprite, startPos + Vector3.up * i, Quaternion.identity);
            stair.transform.parent = transform;
            stairs.Add(stair.GetComponent<SpriteRenderer>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!counter.set)
        {
            degradate =  (int)Math.Floor((1 - (counter.counter / (float) counter.maxCharge)) * (degradation.Count-1));
            if (degradate > _lastDegradate)
            {
                foreach (var stair in stairs)
                {
                    stair.sprite = degradation[degradate];
                }

                _lastDegradate = degradate;
            }
            
        }
        
    }
}
