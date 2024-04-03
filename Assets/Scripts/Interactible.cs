using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    protected Transform playerPosition;

    protected Camera playerCamera;
    private void Start()
    {
        playerCamera = Camera.main;
    }
    public virtual void StartInteraction() 
    {
        playerCamera.transform.SetParent(cameraTransform);
    }
    public virtual void EndInteraction() 
    {
        //Todo give main camera back to player
    }
}
