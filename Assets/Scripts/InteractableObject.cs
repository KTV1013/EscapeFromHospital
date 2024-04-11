using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(PlayerInput))]
public class InteractableObject : Interactable
{
    #region Variables
    [SerializeField] protected Transform cameraTransform;
    [SerializeField] InteractableObject parentInteractableObject;
    [Header("Translate if true,\n Rotate if False")]
    [Space()]
    [SerializeField] protected bool translate;
    [SerializeField] protected Transform pivotPoint;
    [SerializeField] protected Vector2 upperBounds;
    [SerializeField] protected Vector2 lowerBounds;
    [SerializeField] protected float speed;

    protected bool freeRotation;
    protected Vector2 inputVector = Vector2.zero;
    protected Vector2 currentVector = Vector2.zero;
    protected CameraController cameraController;
    protected Camera playerCamera;
    
    protected Interactable interactedObject;
    protected PlayerInput playerInput;
    protected Interactor interactor;

    #endregion Variables
    #region Input Callbacks
    protected virtual void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = false;
        
        InputAction moveAction = playerInput.actions.FindAction("Move");

        moveAction.performed +=
            context =>
            {
                OnMove(context);
            };

        moveAction.canceled +=
            context =>
            {
                OnMove(context);
            };

        InputAction leftClickAction = playerInput.actions.FindAction("LeftClick");

        leftClickAction.started +=
            context =>
            {
                OnLeftClick(context);
            };

        leftClickAction.performed +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    OnLeftHold(context);
            };

        leftClickAction.canceled +=
            context =>
            {
                if (context.interaction is HoldInteraction)
                    OnLeftCancel(context);
            };

        InputAction rightClickAction = playerInput.actions.FindAction("RightClick");

        rightClickAction.started +=
            context =>
            {
                playerInput.enabled = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                if (parentInteractableObject != null)
                {
                    parentInteractableObject.StartInteraction();
                }
                else
                {
                    cameraController.ResetParent();
                    interactor.SetInput(true);
                }
            };

    }
    #endregion Input Callbacks
    #region CameraMovement
    protected virtual void Start()
    {
        playerCamera = Camera.main;
        cameraController = Camera.main.GetComponent<CameraController>();
        interactor = cameraController.transform.parent.parent.GetComponent<Interactor>();
        if (pivotPoint == null)
        {
            pivotPoint = new GameObject(name + " Rotation Point").GetComponent<Transform>();
            pivotPoint.SetParent(transform, false);
        }
        cameraTransform.SetParent(pivotPoint, true);
        freeRotation = upperBounds.x - lowerBounds.x >= 360;
        freeRotation = freeRotation && !translate;
    }

    [ContextMenu("StartInteraction")]
    public override void StartInteraction()
    {
        cameraController.SetParent(cameraTransform);
        interactor.SetInput(false);
        playerInput.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public override void EndInteraction()
    {
        
    }

    protected virtual void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    protected void Update()
    {
        Vector2 newVector = currentVector + Time.deltaTime * speed * inputVector;
        if (!freeRotation)
            newVector.x = Mathf.Clamp(newVector.x, lowerBounds.x, upperBounds.x);
        newVector.y = Mathf.Clamp(newVector.y, lowerBounds.y, upperBounds.y);
        currentVector = newVector;
        if (translate)
        {
            Vector3 position = new(currentVector.x, currentVector.y, 0);
            pivotPoint.SetLocalPositionAndRotation(position, pivotPoint.localRotation);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(currentVector.y, -currentVector.x, 0);
            pivotPoint.SetLocalPositionAndRotation(pivotPoint.localPosition, rotation);
        }
    }
    #endregion CameraMovement
    #region ClickAndDrag
    protected virtual void OnLeftClick(InputAction.CallbackContext callback)
    {
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out interactedObject))
            {
                interactedObject.StartInteraction();
            }
        }
        else { interactedObject = null; }
    }
    protected virtual void OnLeftHold(InputAction.CallbackContext callback)
    {
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            int objectId = hit.transform.gameObject.GetInstanceID();
            if (interactedObject?.GetInstanceID() == objectId)
            {
                Debug.Log("Holding " + interactedObject.name);

            }
        }
    }
    protected virtual void OnLeftCancel(InputAction.CallbackContext callback)
    {
        interactedObject?.EndInteraction();
        interactedObject = null;
    }
    #endregion ClickAndDrag
}
