using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    // Fields

    // References
    [Header("UI Button Sounds")]
    [Tooltip("Press and release click sound.")]
    [SerializeField] AudioSource onOffButton;

    public void PlayOnOffClick()
    {
        onOffButton.Play();
    }
}