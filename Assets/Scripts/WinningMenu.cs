using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningMenu : MonoBehaviour
{
    public Canvas winningCanvas;
    PinCode pinCode; 

    private void Awake()
    {
        winningCanvas.enabled = false;
    }

    private void Update()
    {
        pinCode = GetComponent<PinCode>();
        if (pinCode.GetNewPinCode() == pinCode.GetPinCode())
        {
            winningCanvas.enabled = true;
        }
       
    }


}
