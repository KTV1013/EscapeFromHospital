using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{
    public Canvas winningCanvas;
    PinCode pinCode; 

    private void Awake()
    {
        winningCanvas.enabled = false;
        pinCode = GetComponent<PinCode>();
    }

    private void Update()
    {
        if (pinCode.GetNewPinCode() == pinCode.GetPinCode())
        {
            winningCanvas.enabled = true;
        }
       
    }
    public void OpenScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr);
    }
    public void Quit()
    {
        Application.Quit();
    }


}
