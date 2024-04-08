using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public float timeLeft { get; set; }

    [SerializeField] bool GameIsPaused = false;
    

    private void Awake()
    {
        pauseCanvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pauseTheGame();
        }
        
    }
    private void pauseTheGame()
    {
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0f;
        }
        else if (!GameIsPaused)
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1f;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
