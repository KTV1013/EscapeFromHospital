using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    Interactible parentInteractible;

    protected Camera playerCamera;
    
    private void Start()
    {
        playerCamera = Camera.main;
    }
    [ContextMenu("StartInteraction")]
    public virtual void StartInteraction() 
    {
        playerCamera.transform.SetParent(cameraTransform, true);
    }
    public virtual void EndInteraction()
    {
        if (parentInteractible != null) 
        {
            parentInteractible.StartInteraction();
        }
        else
        {
            //Todo give main camera back to player
        }
    }
}
