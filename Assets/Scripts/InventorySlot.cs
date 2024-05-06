using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public GameObject itemIcon;
    bool hasItem = false;
    public Item slotItem;

    public void setItem(Item itemInfo)
    {
        hasItem = true;
        GameObject newItemIcon = Instantiate(itemIcon, gameObject.transform);
        slotItem = itemInfo;
        transform.GetChild(0).GetComponent<ItemInSlot>().item = slotItem;
        newItemIcon.SetActive(true);
    }

    public bool CheckItem()
    {
        if(transform.childCount > 0)
        {
            hasItem = true;
        }
        else
        {
            hasItem= false;
        }

        return hasItem;
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