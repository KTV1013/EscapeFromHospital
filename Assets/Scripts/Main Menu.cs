using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas guideCanvas;
    private void Start()
    {
        guideCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void StartGame(int sceneNum)
   {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(sceneNum); 
   }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game!!! ");
    }

    public void OpenGuideCanvas()
    {
        guideCanvas.enabled = true;
    }
    public void QuitCanvas()
    {
        guideCanvas.enabled = false;
    }


}
