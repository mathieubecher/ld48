using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCable : MonoBehaviour
{
    [SerializeField] private List<Transform> points;

    private LineRenderer _line;
    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] positions = new Vector3[points.Count];
        for (int i = 0; i < points.Count; ++i)
        {
            positions[i] = (Vector2)points[i].position;
        }
        _line.SetPositions(positions);
    }
}
