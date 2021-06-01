using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerSetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string MasterVolString;
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(MasterVolString, Mathf.Log10(sliderValue) * 20);
    }

}
