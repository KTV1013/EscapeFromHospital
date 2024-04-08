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


public class Interactable : MonoBehaviour
{
    public virtual void StartInteraction() { }

    public virtual void EndInteraction() { }
}
