using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnIventoryView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public DesplayItem desplayItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        desplayItem.canRotate = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desplayItem.canRotate = false;
    }
}
