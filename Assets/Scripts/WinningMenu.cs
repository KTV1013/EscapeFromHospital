using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{
    public Canvas winningCanvas;
    public TextMeshProUGUI playerTimeTxt;
    float playerTime;
    Timer time;
    PinCode pinCode; 

    private void Awake()
    {
        winningCanvas.enabled = false;
        pinCode = GameObject.FindGameObjectWithTag("Code Panel").GetComponent<PinCode>();
        time = GameObject.FindGameObjectWithTag("Timer").GetComponent <Timer>();
    }

    private void Update()
    {
        if (pinCode.GetPlayerInput() == pinCode.GetPinCode())
        {
            Time.timeScale = 0f;
            winningCanvas.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;            
            CalculatePlayerTime();
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
    
    private void CalculatePlayerTime()
    {
        int min;
        int sec;
        playerTime = time.GetTime() - time.GetTimeLeft();
        min = Mathf.FloorToInt(playerTime / 60);
        sec = Mathf.FloorToInt(playerTime % 60);
        playerTimeTxt.text = "You escaped in " + min + " minutes and " + sec + " seconds" ;
    }

}
