using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public Canvas GameOverCanvas;

    Timer time;
    private void Awake()
    {
        time = GetComponent<Timer>();
     
        GameOverCanvas.enabled = false;
    }

    void Update()
    {
        if (time.GetTime() <0 ) { GameOver(); }
    }

    private void GameOver()
    {
        GameOverCanvas.enabled = true;
    }
}
