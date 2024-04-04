using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float Playerspeed = 10f;
    Vector2 _MoveDir;
    public InputActionReference MoveAction;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _MoveDir = MoveAction.action.ReadValue<Vector2>();
       
    }

    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3(_MoveDir.x, 0, _MoveDir.y) * Playerspeed;
        rb.AddForce(Movement * Time.deltaTime, ForceMode.VelocityChange);
    }

}
