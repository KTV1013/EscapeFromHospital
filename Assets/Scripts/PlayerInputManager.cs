using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : Singleton<PlayerInputManager>
{
    [SerializeField]
    Interactor interactor;
    PlayerInput currentInput;

    public void SetInput(PlayerInput input)
    {
        if (currentInput == null) 
        {
            interactor.SetInput(false);
        }
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
        
        currentInput.enabled = false;
        currentInput = null;
        interactor.SetInput(true);
    }
}
