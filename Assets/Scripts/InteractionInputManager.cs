using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InteractionInputManager : Singleton<InteractionInputManager>
{
    PlayerInput playerInput;
    public UnityEvent<InputAction.CallbackContext> onRightClick = new();
    public UnityEvent<InputAction.CallbackContext> onLeftClick = new();
    public UnityEvent<InputAction.CallbackContext> onLeftCancel = new();
    public UnityEvent<InputAction.CallbackContext> onLeftHold = new();
    public UnityEvent<InputAction.CallbackContext> onMove = new();
    
    private void Awake()
    {
        name = "InteractionInputManager";
        playerInput = transform.AddComponent<PlayerInput>();
        playerInput.actions = Resources.Load<InputActionAsset>("InputActions/InteractableInputAction");
        playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        playerInput.neverAutoSwitchControlSchemes = false;
        playerInput.ActivateInput();
        InputAction moveAction = playerInput.actions.FindAction("Move");
        
        moveAction.performed +=
            context =>
            {
                Debug.Log("aaaa");
                onMove.Invoke(context);
            };

        moveAction.canceled +=
            context =>
            {
                onMove.Invoke(context);
            };

        InputAction leftClickAction = playerInput.actions.FindAction("LeftClick");

        leftClickAction.started +=
            context =>
            {
                onLeftClick.Invoke(context);
            };

        leftClickAction.performed +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    onLeftHold.Invoke(context);
            };

        leftClickAction.canceled +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    onLeftCancel.Invoke(context);
            };

        InputAction rightClickAction = playerInput.actions.FindAction("RightClick");

        rightClickAction.started +=
            context =>
            {
                onRightClick.Invoke(context);
            };
    }
    public void AddListener(UnityAction<InputAction.CallbackContext> action)
    {
        onLeftClick.AddListener(action);
    }
}
