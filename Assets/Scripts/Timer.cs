using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float timeLeft;

    [SerializeField] int minutes;
    [SerializeField] int seconds;
    //[SerializeField] TextMeshProUGUI timerText;

    [ContextMenu("Start Timer")]
    //[SerializeField] TextMeshProUGUI timerText;

    private void Awake()
    {
        timeLeft = time;
    }
    private void Update()
    {
        minutes = Mathf.FloorToInt(timeLeft / 60);
        seconds = Mathf.FloorToInt(timeLeft % 60);

        startTimer();
        HalvTimeCheck();
        LastMinuteCheck(minutes,seconds);
    }

    public float GetTime() {  return timeLeft; }
    public void startTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        //timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    private void HalvTimeCheck()
    {
        
        if (timeLeft <= time/2)
        {
            //timerText.color = Color.red;
            Debug.Log("Halv time is gone");
        }
    }
    private void LastMinuteCheck(int min, int sec)
    {
      
        if (min == 1 & sec == 0)
        {
            Debug.Log("One Minute Left");
        }
    }

    
    

}
