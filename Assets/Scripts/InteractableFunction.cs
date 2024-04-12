using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableFunction : Interactable
{
    public UnityEvent startEvent;
    public UnityEvent endEvent;

    public override void EndInteraction()
    {
        endEvent.Invoke();
    }

    public override void StartInteraction()
    {
        startEvent.Invoke();
    }
}