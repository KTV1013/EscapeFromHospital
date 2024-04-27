using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class ItemInSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, 
    IEndDragHandler
{
    public Item item;
    Image icon;
    DesplayItem desplayItem;

    public Transform originalParent;

    void Start()
    {
        desplayItem = GameObject.Find("ItemPlace").GetComponent<DesplayItem>();
        icon = gameObject.GetComponent<Image>();

        Image image = GetComponent<Image>();
        image.sprite = item.icon;
        name = item.name;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (desplayItem != null && item != null)
        {
            if (desplayItem.itemOnView != null && desplayItem.itemNmae != name)
            {
                desplayItem.itemOnView.SetActive(false);
            }

            if (desplayItem.itemNmae != name)
            {
                desplayItem.item = Instantiate(item.gameObject);
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        icon.raycastTarget = true;
        transform.position = originalParent.transform.position;
    }
}