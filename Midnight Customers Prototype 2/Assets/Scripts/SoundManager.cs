using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    [SerializeField] AudioSource[] heavyBaggingSound;
    [SerializeField] AudioSource[] lightBaggingSound;
    [SerializeField] AudioSource[] mediumBaggingSound;
    [SerializeField] AudioSource scannerSound;

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

    public void PlayBaggingSound(int weight)
    {
        int rand = Random.Range(0, 2);
        if (weight == 1)
        {
            lightBaggingSound[rand].Play();
        }
        else if (weight == 2)
        {
            mediumBaggingSound[rand].Play();
        }
        else
        {
            heavyBaggingSound[rand].Play();
        }
    }

    public void PlayScannerSound()
    {
        scannerSound.Play();
    }
}