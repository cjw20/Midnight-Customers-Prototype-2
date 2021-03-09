using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm.Play(); //looping?
    }

    public void PauseBGM()
    {
        bgm.Pause();
    }

    public void UnpauseBGM()
    {
        bgm.UnPause();
    }
}
