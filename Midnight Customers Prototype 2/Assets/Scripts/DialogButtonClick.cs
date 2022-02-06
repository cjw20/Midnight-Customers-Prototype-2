using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButtonClick : MonoBehaviour
{
    // References
    SoundManager soundManager;
    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    public void TriggerSound()
    {
        soundManager.PlayButtonSound(0);
    }
}