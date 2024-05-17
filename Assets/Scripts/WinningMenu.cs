using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{
    public Canvas winningCanvas;
    public Canvas inventoryCanvas;
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
           ShowWinningCanvas();
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

    private void ShowWinningCanvas()
    {
        Time.timeScale = 0f;
        winningCanvas.enabled = true;
        inventoryCanvas.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
