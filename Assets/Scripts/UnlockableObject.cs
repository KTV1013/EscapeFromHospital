using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockableObject : Interactable
{
    EquippedItem equippedGetter;
    public Item key;
    public bool removeItem = true;
    public UnityEvent unlock;

    private void Start()
    {
        equippedGetter = PlayerInputManager.instance.GetComponent<EquippedItem>();
    }
    public override void EndInteraction()
    {
        
    }

    public override void StartInteraction()
    {
        if (key == null)
        {
            Debug.LogError("Missing Key: " + name);
            return;
        }
        Debug.Log(equippedGetter.GetItem());
        if (equippedGetter.GetItem().Equals(key.name)) 
        {

            unlock.Invoke();
            if (removeItem) 
                equippedGetter.RemoveItem();
            Destroy(this);
        }
    }
}
