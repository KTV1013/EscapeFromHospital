using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPuzzle : MonoBehaviour
{
    //Inventory inventory;
    List<InventorySlot> slots;
    [SerializeField] List<string> batteris = new List<string>();
    EquippedItem equippedItem;
    GameObject player;

    [SerializeField] bool hasBattery = false;
    [SerializeField] bool hasFlashlight = false;
    [SerializeField] Light spotLight;
    
    void Start()
    {
       //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
       //slots = inventory.GetInventory();
       player = GameObject.FindGameObjectWithTag("Player");
       slots = player.GetComponent<Inventory>().GetInventory();
       equippedItem = player.GetComponent<EquippedItem>();
    }

    
    void Update()
    {
        BatteryCheck();
        FlashlightCheck();
        if (hasBattery && hasFlashlight)
        {
            spotLight.enabled = true;
        }
    }

    private void BatteryCheck()
    {
        foreach (InventorySlot slot in slots)
        {
            for (int i = 0; i < slot.transform.childCount; i++)
            {
                Transform child = slot.transform.GetChild(i);
                string childName = child.name;               
                if (childName == "Battery")
                {
                    batteris.Add(childName);
                    //hasBattery = true;
                }
            }
        }
    }

    private void FlashlightCheck()
    {
        if (equippedItem.name != null)
        {
            if (equippedItem.GetItem() == "flashlight")
            {
                hasFlashlight = true;
            }
        }
    }
}
