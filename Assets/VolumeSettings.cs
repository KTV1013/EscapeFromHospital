using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using Unity.Mathematics;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;

    public void SetMaterVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Master_Volume", math.log10(volume)*20);
    }

}
