using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Interactable
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public override void EndInteraction()
    {

    }

    public override void StartInteraction()
    {
        RotateGear();
    }

    // Funktion för att rotarea på Gear 
    public void RotateGear()
    {
        transform.Rotate(new Vector3(-36f, 0f, 0f));
        audioManager.PlaySFX(audioManager.GearSound);
        Debug.Log("Gear Roterad");
    }
}