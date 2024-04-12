using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragableObject : Interactable
{
    [SerializeField] protected float drag = 5f;
    Camera mainCamera;
    Rigidbody body;
    bool dragged = false;
    private void Start()
    {
        mainCamera = Camera.main;
        body = GetComponent<Rigidbody>();
    }
    public override void StartInteraction()
    {
        dragged = true;
    }
    public override void EndInteraction()
    {
        dragged = false;
    }
    private void FixedUpdate()
    {
        if (!dragged) return;

        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
        Vector3 screenDirection = Input.mousePosition - screenPoint;
        Vector3 worldDirection = screenDirection.x * mainCamera.transform.right;
        worldDirection += screenDirection.y * mainCamera.transform.up;
        body.AddForce(worldDirection * 2);
        body.AddForce(-drag * body.velocity);
    }
}
