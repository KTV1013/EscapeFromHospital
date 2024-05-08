using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayScreenImage : MonoBehaviour
{
    public Material screenOff;
    public Material screenOn;
    public Material hand;
    public Material handWithKey;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = screenOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Renderer>().material = screenOn;
        }
    }
}
