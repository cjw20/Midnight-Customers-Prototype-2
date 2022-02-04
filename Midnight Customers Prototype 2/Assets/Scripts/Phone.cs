using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    // Fields

    // References
    [Tooltip("Reference to the Sound Manager.")]
    [SerializeField] SoundManager soundManager;
    public void ClosePhone()
    {
        soundManager.PlayPhoneLockSound();
        this.gameObject.SetActive(false);
    }
}