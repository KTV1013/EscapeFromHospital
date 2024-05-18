using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockableObject : Interactable
{
    EquippedItem equippedGetter;
    public Item key;
    public string keyNameOverride;
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
        bool overrideName = !keyNameOverride.Equals(string.Empty);
        if (key == null && !overrideName)
        {
            Debug.LogError("Missing Key: " + name);
            return;
        }
        string keyName = key.name;
        if (overrideName)
            keyName = keyNameOverride;
        if (equippedGetter.GetItem().Equals(keyName)) 
        {

            unlock.Invoke();
            if (removeItem) 
                equippedGetter.RemoveItem();
            Destroy(this);
        }
    }
}
