using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] float sens = 200f;
    Transform PlayerTransform; 
    float xRot = 0f; 

    void Start()
    {
        PlayerTransform = gameObject.transform.parent; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime; 
        xRot -= MouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        gameObject.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        PlayerTransform.transform.Rotate(Vector3.up * MouseX);
    }

}
