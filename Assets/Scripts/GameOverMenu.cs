using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
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
