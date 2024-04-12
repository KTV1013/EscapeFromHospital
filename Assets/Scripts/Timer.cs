using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;    
    //[SerializeField] TextMeshProUGUI timerText;

    [ContextMenu("Start Timer")]


    private void Update()
    {
        startTimer();
        HalvTimeCheck();
    }

    public float GetTime() {  return time; }
    public void startTimer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 0)
        {
            time = 0;
        }
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        //timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    private void HalvTimeCheck()
    {
        if (time <= time/2)
        {
         //timerText.color = Color.red;       
        }
    }

    
    

}
