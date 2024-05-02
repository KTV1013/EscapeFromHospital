using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockableObject : Interactable
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
        if (Key == null)
        {
            Debug.LogError("Missing Key: " + name);
            return;
        }
        Debug.Log(equippedGetter.GetItem());
        Debug.Log(Key.name);
        if (equippedGetter.GetItem().Equals(Key.name)) 
        {
            Unlock.Invoke();
            Destroy(this);
        }
    }
}
