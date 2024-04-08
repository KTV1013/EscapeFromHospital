using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;    
    //[SerializeField] TextMeshProUGUI timerText;

    [ContextMenu("Start Timer")]

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
    private void Update()
    {
        startTimer();
    }
    public float GetTime() {  return time; }

}
