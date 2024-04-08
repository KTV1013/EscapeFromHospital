using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    protected Transform RotationPoint;
    [SerializeField]
    protected Transform playerPosition;
    [SerializeField]
    Interactible parentInteractible;
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
        if (parentInteractible != null) 
        {
            parentInteractible.StartInteraction();
        }
        else
        {
            //Todo give main camera back to player
        }
    }

    protected IEnumerator LerpCamera()
    {
        while (playerCamera.transform.localPosition != Vector3.zero)
        {
            Vector3.Lerp(playerCamera.transform.position, Vector3.zero, 0.3f);
            yield return null;
        }
    }
}
