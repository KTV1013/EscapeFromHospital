using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    public GameObject itemPlaceInHand;
    public EquipmentSlot equipmentSlot;
    GameObject item;
    ItemInSlot itemInSlot;

    private void Update()
    {
        if (equipmentSlot.CheckItem())
        {
            itemInSlot = equipmentSlot.GetComponentInChildren<ItemInSlot>();
            item = itemInSlot.item.gameObject;
            item.transform.SetParent(itemPlaceInHand.transform);
            item.transform.position = itemPlaceInHand.transform.position;
            item.transform.rotation = itemPlaceInHand.transform.rotation;
            item.SetActive(true);
            item.GetComponent<Collider>().enabled = false;

            if(itemPlaceInHand.transform.childCount > 1)
            {
                GameObject firstItem = itemPlaceInHand.transform.GetChild(0).gameObject;
                firstItem.SetActive(false);
                firstItem.GetComponent<Collider>().enabled = true;
                firstItem.transform.SetParent(itemPlaceInHand.transform.parent.transform);
            }
        }
        else if(!equipmentSlot.CheckItem() && item)
        {
            item.SetActive(false);
            item.GetComponent<Collider>().enabled = true;
            item.transform.SetParent(itemPlaceInHand.transform.parent.transform);
        }
    }
}
