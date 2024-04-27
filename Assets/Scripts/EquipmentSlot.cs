using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public GameObject itemIcon;
    bool hasItem = false;
    public Item slotItem;

    public void setItem(Item itemInfo)
    {
        hasItem = true;
        Instantiate(itemIcon, gameObject.transform);
        slotItem = itemInfo;
        gameObject.transform.GetChild(0).GetComponent<ItemInSlot>().item = slotItem;
    }

    public bool CheckItem()
    {
        if (transform.childCount > 0)
        {
            hasItem = true;

        }
        else
        {
            hasItem = false;
        }

        return hasItem;
    }

    public Item GetItem()
    {
        return slotItem;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped.CompareTag("ItemIcon"))
        {
            ItemInSlot item = dropped.GetComponent<ItemInSlot>();
            CheckItem();
            if (hasItem)
            {
                SwapItem(item);
                item.originalParent = transform;
            }
            else
            {
                item.originalParent = transform;
            }
        }
    }

    void SwapItem(ItemInSlot itemToSwap)
    {
        gameObject.transform.GetChild(0).transform.SetParent(itemToSwap.originalParent);
        slotItem = itemToSwap.item;
    }
}
