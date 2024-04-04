using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] float sens = 200f;
    public InputActionReference mouse;
    Transform PlayerTransform;
    Vector2 _MouseDir;
    float xRot = 0f; 

    void Start()
    {
        PlayerTransform = gameObject.transform.parent; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _MouseDir = mouse.action.ReadValue<Vector2>();  
        float mouseX = _MouseDir.x * sens * Time.deltaTime; 
        float mouseY = _MouseDir.y * sens * Time.deltaTime;
        xRot -= mouseY; 
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        gameObject.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        PlayerTransform.transform.Rotate(Vector3.up * mouseX);
    }

}
