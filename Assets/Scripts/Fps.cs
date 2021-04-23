using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    private const int MAXFPS = 120;
    private TextMeshProUGUI _text;
    private List<float> _frames;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _frames = new List<float>();
    }
    
    private void Update()
    {
        _frames.Add(Time.deltaTime);
        while (_frames.Count > MAXFPS)
            _frames.Remove(_frames.First());

        float sum = 0.0f;
        foreach (float frame in _frames)
            sum += frame;
        
        _text.text = ((int)(MAXFPS/sum)).ToString();
    }
}
