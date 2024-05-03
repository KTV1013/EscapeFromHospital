using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPuzzle : MonoBehaviour
{
    List<InventorySlot> slots;
    EquippedItem equippedItem;
    GameObject player;

    [SerializeField] bool hasBattery = false;
    [SerializeField] bool hasFlashlight = false;
    public Light spotLight;

    [SerializeField] bool on = false;
    [SerializeField] bool off = true;
    
    void Start()
    {
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
            //TurnOn();
            if (off && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Light trun on");
                TurnOn();
            }
            else if (on && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Light off");
                TurnOff();
            }
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
                    hasBattery = true;
                }
            }

        }
    }

    private void FlashlightCheck()
    {
        if (equippedItem.name != null)
        {
            if (equippedItem.GetItem() == "Flashlight")
            {
                hasFlashlight = true;
            }
        }
    }

    private void TurnOn()
    {
        spotLight.enabled = true;
        off = false;
        on = true;
    }
    private void TurnOff()
    {
        spotLight.enabled=false;
        off = true;
        on = false;
    }
}
