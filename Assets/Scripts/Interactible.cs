using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(PlayerInput))]
public class Interactible : MonoBehaviour
{
    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    Interactible parentInteractible;
    [SerializeField]
    [Header("Translate if true,\n Rotate if False")]
    [Space()]
    protected bool translate;
    [SerializeField]
    protected Transform pivotPoint;
    [SerializeField]
    protected Vector2 upperBounds;
    [SerializeField]
    protected Vector2 lowerBounds;
    [SerializeField]
    protected float speed;

    protected Vector2 inputVector = Vector2.zero;
    protected Vector2 currentVector = Vector2.zero;
    protected CameraController cameraController;
    protected Camera playerCamera;
    protected PlayerInput playerInput;

    private void Start()
    {
        playerCamera = Camera.main;
        cameraController = Camera.main.GetComponent<CameraController>();
        if (pivotPoint == null)
        {
            pivotPoint = new GameObject(name + " Rotation Point").GetComponent<Transform>();
            pivotPoint.SetParent(transform, false);
        }
        cameraTransform.SetParent(pivotPoint, true);
        playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = false;
        
    }
    
    [ContextMenu("StartInteraction")]
    public virtual void StartInteraction() 
    {
        playerInput.enabled = true;
        cameraController.SetParent(cameraTransform);
        inputVector = Vector2.zero;
        pivotPoint.localRotation = Quaternion.identity;
    }

    public virtual void EndInteraction()
    {
        playerInput.enabled = false;
        if (parentInteractible != null) 
        {
            parentInteractible.StartInteraction();
        }
        else
        {
            cameraController.ResetParent();
        }
    }

    protected virtual void OnMove(InputValue moveValue)
    {
        inputVector = moveValue.Get<Vector2>();
    }

    protected void Update()
    {
        Vector2 newVector = currentVector + Time.deltaTime * speed * inputVector;
        currentVector.x = Mathf.Clamp(newVector.x, lowerBounds.x, upperBounds.x);
        currentVector.y = Mathf.Clamp(newVector.y, lowerBounds.y, upperBounds.y);
        if (translate)
        {
            Vector3 position = new(currentVector.x, currentVector.y, 0);
            pivotPoint.SetLocalPositionAndRotation(position, pivotPoint.localRotation);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(currentVector.y, -currentVector.x, 0);
            pivotPoint.SetLocalPositionAndRotation(pivotPoint.localPosition, rotation);
        }
    }
}
