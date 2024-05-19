using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class SlotItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item hasItem;

    DesplayItem desplayItem;
    Image image;

    void Start()
    {
        desplayItem = GameObject.Find("ItemPlace").GetComponent<DesplayItem>();
        image = gameObject.GetComponent<Image>();
    }

    public void initializeSlot()
    {
        setItem(null);
    }

    public void setItem(Item item)
    {
        hasItem = item;
        image.sprite = hasItem.icon;
    }

    public Item getItem()
    {
        return hasItem;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (desplayItem != null && hasItem != null)
        {
            if (desplayItem.itemOnView != null && desplayItem.itemNmae != name)
            {
                desplayItem.itemOnView.SetActive(false);
            }

            if (desplayItem.itemNmae != name)
            {
                desplayItem.item = Instantiate(hasItem.gameObject);
                desplayItem.item.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (desplayItem != null)
        {
            Destroy(desplayItem.item);

            if (desplayItem.itemOnView != null)
                desplayItem.itemOnView.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            desplayItem.itemNmae = name;

            if (desplayItem.item != null && desplayItem.itemOnView == null)
            {
                desplayItem.itemOnView = Instantiate(desplayItem.item);
            }

            else if (desplayItem.item != null && desplayItem.itemOnView != null)
            {
                Destroy(desplayItem.itemOnView);
                desplayItem.itemOnView = Instantiate(desplayItem.item);
            }
        }

    }
}