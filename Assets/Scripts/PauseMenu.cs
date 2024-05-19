using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas winningCanvas;
    public Canvas inventoryCanvas;
   
    public float timeLeft { get; set; }
    [SerializeField] bool GameIsPaused = false;
    

    private void Awake()
    {
        pauseCanvas.enabled = false;
        Continue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!winningCanvas.enabled)
            {
                pauseTheGame();
            }
            
        }
        
    }
    private void pauseTheGame()
    {
        GameIsPaused = !GameIsPaused;
        
        if (GameIsPaused)
        {
            pauseCanvas.enabled = true;
            inventoryCanvas.enabled = false;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (!GameIsPaused)
        {
            pauseCanvas.enabled = false;
            inventoryCanvas.enabled = true;
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        inventoryCanvas.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

 
    public void OpenScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        SceneManager.LoadScene(sceneIndex);
    }

    
}
