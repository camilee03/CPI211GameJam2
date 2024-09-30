using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Scrollbar")]
    Scrollbar slider;

    [Header("time")]
    float time = 0.01f;

    private void Start()
    {
        slider = GetComponent<Scrollbar>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.size += time*Time.deltaTime;  
        
        if (slider.size == 1)
        {
            // bad things happen
        }
    }
}
