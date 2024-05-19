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
    [SerializeField] bool puzzleSolved = false;
    public Light spotLight;

    [SerializeField] bool on = false;
    [SerializeField] bool off = true;

    AudioManager audioManager;
    
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
        slots = player.GetComponent<Inventory>().GetInventory();
        equippedItem = player.GetComponent<EquippedItem>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    
    void Update()
    {
        BatteryCheck();
        FlashlightCheck();
        if (hasBattery && hasFlashlight)
        {
            puzzleSolved = true;
            //if (off && Input.GetKeyDown(KeyCode.F))
            //{
            //    Debug.Log("Light trun on");
            //    TurnOn();
            //}
            //else if (on && Input.GetKeyDown(KeyCode.F))
            //{
            //    Debug.Log("Light off");
            //    TurnOff();
            //}
        }
        if (puzzleSolved)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                on = !on;
                TurnOn();
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
                    return;
                }
            }

        }
    }

    private void FlashlightCheck()
    {        
        if (equippedItem.GetItem() == "Flashlight")
        {
                hasFlashlight = true;
        }
        else
        {
                hasFlashlight = false;
        }
    }

    private void TurnOn()
    {
        if (on)
        {
            spotLight.enabled = true;
        }
        else if (!on)
        {
            spotLight.enabled = false;
        }
        //Debug.Log("ON");
        //audioManager.PlaySFX(audioManager.switchingsound);
        //spotLight.enabled = true;
        //off = false;
        //on = true;
    }
    private void TurnOff()
    {
        Debug.Log("OFF");
        audioManager.PlaySFX(audioManager.switchingsound);
        spotLight.enabled=false;
        off = true;
        on = false;
    }
}
