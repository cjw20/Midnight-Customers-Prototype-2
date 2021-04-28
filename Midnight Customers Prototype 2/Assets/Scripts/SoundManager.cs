using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public AudioSource bgm;
    FMOD.Studio.EventInstance gameMusic;
    FMOD.Studio.EventInstance environmentAmbience;

    // Start is called before the first frame update
    void Start()
    {
        //bgm.Play(); //looping?

        //calls directly from code, doesn't need an emitter on an object in the scene
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/music");
        gameMusic.start();
        environmentAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/ambience");
        environmentAmbience.start();
    }

    public void PauseBGM()
    {
        //bgm.Pause();
        gameMusic.setPaused(true);
    }

    public void UnpauseBGM()
    {
        //bgm.UnPause();
        gameMusic.setPaused(false);
    }
}
