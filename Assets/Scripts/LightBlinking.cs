using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    Light light;
    [SerializeField] float blinkInterval = 1.0f; 
    float timer;

    private void Awake()
    {
        light = GetComponent<Light>();
        timer = blinkInterval; 
    }

    private void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0)
        {
            light.enabled = !light.enabled; 
            timer = blinkInterval;
        }
    }

}
