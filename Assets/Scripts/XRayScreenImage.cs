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
    public Sprite handWithKeyIcon;

    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        render.material = screenOff;
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
            item.GetComponent<Item>().icon = handWithKeyIcon;
            item.GetComponent<Item>().name = "Hand With Key";
        }
        else
        {
            render.material = hand;
        }
    }
}
