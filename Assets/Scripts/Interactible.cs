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
    protected CameraController cameraController;
    
    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    
    [ContextMenu("StartInteraction")]
    public virtual void StartInteraction() 
    {
        cameraController.SetParent(cameraTransform);
    }

    public virtual void EndInteraction()
    {
        if (parentInteractible != null) 
        {
            parentInteractible.StartInteraction();
        }
        else
        {
            cameraController.ResetParent();
        }
    }
}
