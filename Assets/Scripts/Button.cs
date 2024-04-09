using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int num;
    Ray ray;

    [ContextMenu("Press")]

    public string GetNum()
    {
        Debug.Log(num.ToString());
        return num.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.collider.gameObject.name);
        }
    }


}
