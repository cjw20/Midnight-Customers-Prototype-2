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
    [SerializeField] AudioSource[] humanFootStepSound;
    [SerializeField] AudioSource cashRegisterSound;
    [SerializeField] AudioSource drawerSound;
    [SerializeField] AudioSource doorbell;
    [SerializeField] AudioSource sweepingSound;
    [SerializeField] AudioSource breakerSwitch;
    [SerializeField] AudioSource screwLightbulbSound;
    [SerializeField] AudioSource chipsPickUpSound;
    [SerializeField] AudioSource chipsPutDownSound;

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

    public void PlayPlayerFootstepSounds()
    {
        int rand = Random.Range(0, 3);
        humanFootStepSound[rand].Play();
    }

    public void PlayCashRegisterSound()
    {
        cashRegisterSound.Play();
    }

    public void PlayDrawerSound()
    {
        drawerSound.Play();
    }

    public void PlayDoorbellSound()
    {
        doorbell.Play();
    }

    public void PlaySweepingSound()
    {
        if (!sweepingSound.isPlaying)
        {
            sweepingSound.Play();
        }
    }

    public void PauseSweepingSound()
    {
        if (sweepingSound.isPlaying)
        {
            sweepingSound.Pause();
        }
    }

    public void StopSweepingSound()
    {
        if (sweepingSound.isPlaying)
        {
            sweepingSound.Stop();
        }
    }

    public void PlayBreakerSwitchSound()
    {
        breakerSwitch.Play();
    }

    public void PlayScrewLightbulbSound()
    {
        if (!screwLightbulbSound.isPlaying)
        {
            screwLightbulbSound.Play();
        }
    }

    public void PlayChipsUpSound()
    {
        chipsPickUpSound.Play();
    }

    public void PlayChipsDownSound()
    {
        chipsPutDownSound.Play();
    }
}