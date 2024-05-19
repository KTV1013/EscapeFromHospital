using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemTrigger : MonoBehaviour
{
    public GameObject itemPlace;
    public XRayScreenImage screen;
    EquipmentSlot equipmentItem;
    private bool playerIn = false;

    private void Start()
    {
        equipmentItem = GameObject.Find("Player").GetComponentInChildren<EquipmentSlot>();
    }

    private void Update()
    {
        if (itemPlace.transform.childCount == 0)
        {
            screen.ActivateXRayMachine();
        }

        if (playerIn)
        {
            PlaceItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }

    void PlaceItem()
    {
        if (itemPlace.transform.childCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && equipmentItem.hasItem)
            {
                if (equipmentItem.slotItem.name == "Hand" || equipmentItem.slotItem.name == "Hand With Key")
                {
                    screen.SetImage(equipmentItem.slotItem.gameObject);
                    GameObject item = Instantiate(equipmentItem.slotItem.gameObject, itemPlace.transform);
                    item.gameObject.layer = 0;
                    item.GetComponent<CapsuleCollider>().enabled = true;
                    item.transform.localPosition = new Vector3(0, 0, 0);

                    equipmentItem.RemoveItem();
                    itemPlace.GetComponent<XRayScan>().MoveIn();
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && itemPlace.transform.childCount > 0)
        {
            Debug.Log("There is an item in");
        }
    }
}
