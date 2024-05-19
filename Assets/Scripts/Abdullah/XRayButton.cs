using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class XRayButton : MonoBehaviour
{
    public Animator pressButton;
    float raycastDistance = 5f;
    public GameObject itemPlace;
    public Sprite handWithKeyIcon;
    Item itemInsideXray;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistance) && hit.collider.gameObject.name == "button")
        {
            if (Input.GetMouseButtonDown(0))
            {
                itemInsideXray = itemPlace.GetComponentInChildren<Item>();
                pressButton.SetTrigger("PressButton");
                if (itemInsideXray.gameObject.GetComponent<HasKey>())
                {
                    itemInsideXray.icon = handWithKeyIcon;
                    itemInsideXray.name = "Hand With Key";
                }
                itemInsideXray.gameObject.layer = 6;

                if (itemPlace.transform.childCount > 0)
                {
                    itemPlace.GetComponent<XRayScan>().MoveOut();
                }
            }
        }
    }
}
