using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int quality){
        QualitySettings.SetQualityLevel(quality);
    }
}
