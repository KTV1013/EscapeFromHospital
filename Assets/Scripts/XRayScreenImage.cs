using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayScreenImage : MonoBehaviour
{
    public Material screenOff;
    public Material screenOn;
    public Material hand;
    public Material handWithKey;
    public Renderer render;

    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        render.material = screenOff;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            render.material = screenOn;
        }
    }

    public void ActivateXRayMachine()
    {
        render.material = screenOn;
    }

    public void GetManiuMaterial()
    {
        render.material = screenOn;
    }

    public void SetImage(GameObject item)
    {
        if (item.GetComponent<HasKey>())
        {
            render.material = handWithKey;
        }
        else
        {
            render.material = hand;
        }
    }
}
