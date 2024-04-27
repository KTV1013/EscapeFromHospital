using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DesplayItem : MonoBehaviour
{
    public GameObject item;
    public GameObject itemOnView;
    public string itemNmae;
    float speed = 500;
    public bool canRotate = false;

    private void Update()
    {
        if (item != null)
        {
            item.transform.position = gameObject.transform.position;
        }
        
        if(Input.GetMouseButton(0) && itemOnView != null && canRotate)
        {
            float MouseXAxis = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            float MouseYAxis = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

            itemOnView.transform.Rotate(Vector3.up, -MouseXAxis, Space.World);
            itemOnView.transform.Rotate(Vector3.right, MouseYAxis, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.Tab) && item != null)
        {
            Destroy(item);
            canRotate = false;
        }
    }
}
