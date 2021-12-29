using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // References
    [Header("Music/Ambiance Sounds")]
    [Tooltip("Background music.")]
    public AudioSource bgm;
    [Header("Checkout Sounds")]
    [Tooltip("Sounds of heavy objects being put in bag.")]
    [SerializeField] AudioSource[] heavyBaggingSound;
    [Tooltip("Sounds of light objects being put in bag.")]
    [SerializeField] AudioSource[] lightBaggingSound;
    [Tooltip("Sounds of medium objects being put in bag.")]
    [SerializeField] AudioSource[] mediumBaggingSound;
    [Tooltip("Sound for the barcode scanner.")]
    [SerializeField] AudioSource scannerSound;
    [Tooltip("Sound for the cash register.")]
    [SerializeField] AudioSource cashRegisterSound;
    [Tooltip("Sound for the prohibited item drawer.")]
    [SerializeField] AudioSource drawerSound;
    [Header("Minigame Sounds")]
    [Tooltip("Sound for the mopping minigame.")]
    [SerializeField] AudioSource sweepingSound;
    [Tooltip("Sound for toggling the breaker switches.")]
    [SerializeField] AudioSource breakerSwitch;
    [Tooltip("Sound for screwing a lightbulb.")]
    [SerializeField] AudioSource screwLightbulbSound;
    [Tooltip("Sound for picking up a bag of chips.")]
    [SerializeField] AudioSource chipsPickUpSound;
    [Tooltip("Sound for setting down a bag of chips.")]
    [SerializeField] AudioSource chipsPutDownSound;

    [Header("Misc Sounds")]
    [Tooltip("Human footstep sounds.")]
    [SerializeField] AudioSource[] humanFootStepSound;
    [Tooltip("Sound for the door chime.")]
    [SerializeField] AudioSource doorbell;

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