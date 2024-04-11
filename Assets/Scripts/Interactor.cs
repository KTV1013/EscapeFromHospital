using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
public class Interactor : MonoBehaviour
{
    PlayerInput playerInput;
    Interactable interactedObject;
    Camera playerCamera;
    PlayerMovement playerMovement;
    MouseController mouseController;
    private void Start()
    {
        playerCamera = Camera.main;
        playerMovement = GetComponent<PlayerMovement>();
        mouseController = playerCamera.GetComponentInParent<MouseController>();
    }
    #region Input
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        InputAction leftClickAction = playerInput.actions.FindAction("LeftClick");

        leftClickAction.started +=
            context =>
            {
                OnLeftClick(context);
            };

        leftClickAction.performed +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    OnLeftHold(context);
            };

        leftClickAction.canceled +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    OnLeftCancel(context);
            };

        InputAction rightClickAction = playerInput.actions.FindAction("RightClick");
    }
    #endregion Input
    #region OnClick
    private void OnLeftCancel(InputAction.CallbackContext context)
    {
        interactedObject?.EndInteraction();
        interactedObject = null;
    }

    private void OnLeftHold(InputAction.CallbackContext context)
    {
        
    }

    private void OnLeftClick(InputAction.CallbackContext context)
    {
        Vector3 position = playerCamera.transform.position;
        Vector3 forward = playerCamera.transform.forward;
        Ray mouseRay = new(position, forward);

        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out interactedObject))
            {
                interactedObject.StartInteraction();
            }
        }
        else { interactedObject = null; }
    }

    internal void SetInput(bool enabled)
    {
        playerMovement.enabled = enabled;
        mouseController.enabled = enabled;
        playerInput.enabled = enabled;
    }

    #endregion OnClick
}
