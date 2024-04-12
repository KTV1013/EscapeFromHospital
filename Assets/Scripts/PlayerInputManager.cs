using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : Singleton<PlayerInputManager>
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] MouseController mouseController;
    [SerializeField] PlayerInput playerInput;
    
    PlayerInput currentInput;

    public void SetInput(PlayerInput input)
    {
        if (currentInput == null) 
        {
            movement.enabled = false;
            mouseController.enabled = false;
        }
        ChangeCurrentInput(input);
    }

    void ChangeCurrentInput(PlayerInput input)
    {
        if (currentInput != null)
            currentInput.enabled = false;
        if (input != null)
        {
            currentInput = input;
            currentInput.enabled = true;
        }
    }

    public void ResetInput()
    {
        mouseController.enabled = true;
        movement.enabled = true;
        currentInput.enabled = false;
        currentInput = null;
        playerInput.enabled = true;
    }
}
