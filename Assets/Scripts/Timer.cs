using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float timeLeft;

    [SerializeField] int minutes;
    [SerializeField] int seconds;
    public TextMeshProUGUI timerText;
    AudioManager audioManager;
    bool halvTimeAlarmPlayed = false;


    private void Awake()
    {
        timeLeft = time;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        minutes = Mathf.FloorToInt(timeLeft / 60);
        seconds = Mathf.FloorToInt(timeLeft % 60);
        
        startTimer();
        HalvTimeCheck();
        LastMinuteCheck(minutes, seconds);   
    }

    public float GetTime() {  return time; }
    public float GetTimeLeft() { return timeLeft; }
    public void startTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft < 0)
        {
            timeLeft = 0;
            SceneManager.LoadScene(2);
        }

        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    private void HalvTimeCheck()
    {

        if (timeLeft <= time / 2 && !halvTimeAlarmPlayed) 
        {
            audioManager.PlaySFX(audioManager.Alarmsound);
            Debug.Log("Alarm on Alarm on ");
            timerText.color = Color.red;
            halvTimeAlarmPlayed = true;
        }
    }
    private void LastMinuteCheck(int min, int sec)
    {
      
        if (min == 1 & sec == 0)
        {
            //Debug.Log("One Minute Left");
        }
    }

    
    

}
