using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioClip musicSourceGameOver; "Source for the music" 
    [SerializeField] AudioSource SFXSorce;

    [Header("Audio Clip")]
    public AudioClip BackgroundMusic;
    public AudioClip KeysSound;
    public AudioClip Alarmsound;
    public AudioClip UnlockSoundForLockWithCode;
    public AudioClip Lockedsound;
    public AudioClip GearSound;
    public AudioClip switchingsound;
    public AudioClip UnlockSoundForLockWithNumbers; 
    //public AudioClip GameroverClip; "Game over music clip "

    private void Start()
    {
        musicSource.clip = BackgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSorce.PlayOneShot(clip);
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    //If you want to add background music on the "Game over scene"  
    //public void gameovermusic()
    //{
    //    musicSourceGameOver.clip = GameroverClip;
    //    musicSourceGameOver.Play();
    //}
}
