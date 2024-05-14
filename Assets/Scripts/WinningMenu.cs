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
        pinCode = GameObject.FindGameObjectWithTag("Code Panel").GetComponent<PinCode>();
    }

    private void Update()
    {
        if (pinCode.GetPlayerInput() == pinCode.GetPinCode())
        {
            Time.timeScale = 0f;
            winningCanvas.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined; 

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
