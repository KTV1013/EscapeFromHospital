using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UlockableObject : Interactable
{
    EquippedItem equippedGetter;
    public Item Key;
    public UnityEvent Unlock;

    private void Start()
    {
        equippedGetter = PlayerInputManager.instance.GetComponent<EquippedItem>();
    }
    public override void EndInteraction()
    {
        
    }

    public override void StartInteraction()
    {
        if (equippedGetter.GetItem() == Key.name) 
        {
            Unlock.Invoke();
            this.enabled = false;
        }
    }
}
