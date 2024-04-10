using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableFunction : Interactable
{
    public UnityEvent eventToCall;

    public override void EndInteraction()
    {
        
    }

    public override void StartInteraction()
    {
        eventToCall.Invoke();
    }
}