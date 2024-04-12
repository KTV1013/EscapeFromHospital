using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;


public abstract class Interactable : MonoBehaviour
{
    public abstract void StartInteraction();
    public abstract void EndInteraction();
}
