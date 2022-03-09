using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // References
    [Header("Music/Ambiance Sounds")]
    [Tooltip("Background music.")]
    public AudioSource bgm;
    [Tooltip("Rain/Storm Sounds.")]
    [SerializeField] AudioSource rain;
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
    [Tooltip("Sounds of aluminum cans being picked up.")]
    [SerializeField] AudioSource[] aluminumCanPickUpSound;
    [Tooltip("Sounds of aluminum cans being set down.")]
    [SerializeField] AudioSource[] aluminumCanPutDownSound;
    [Tooltip("Sounds of glass bottles being picked up.")]
    [SerializeField] AudioSource[] glassBottlePickUpSound;
    [Tooltip("Sounds of glass bottles being put down.")]
    [SerializeField] AudioSource[] glassBottlePutDownSound;
    [Tooltip("Sounds of water bottles being picked up.")]
    [SerializeField] AudioSource[] waterBottlePickUpSound;
    [Tooltip("Sounds of water bottles being put down.")]
    [SerializeField] AudioSource[] waterBottlePutDownSound;
    [Tooltip("Sounds of money being picked up.")]
    [SerializeField] AudioSource moneyPickUpSound;
    [Tooltip("Sounds of money being put down.")]
    [SerializeField] AudioSource moneyPutDownSound;
    [Tooltip("Sounds of candybars being picked up.")]
    [SerializeField] AudioSource[] candybarPickUpSound;
    [Tooltip("Sounds of candybars being put down.")]
    [SerializeField] AudioSource[] candybarPutDownSound;
    [Tooltip("Sounds of ticket/card being picked up.")]
    [SerializeField] AudioSource[] cardPickUpSound;
    [Tooltip("Sounds of ticket/card being put down.")]
    [SerializeField] AudioSource[] cardPutDownSound;
    [Tooltip("Sounds of car fluid being picked up.")]
    [SerializeField] AudioSource[] carFluidPickUpSound;
    [Tooltip("Sounds of car fluid being put down.")]
    [SerializeField] AudioSource[] carFluidPutDownSound;
    [Tooltip("Sounds of charger being picked up.")]
    [SerializeField] AudioSource[] chargerPickUpSound;
    [Tooltip("Sounds of charger being put down.")]
    [SerializeField] AudioSource[] chargerPutDownSound;
    //[Tooltip("Sounds of cigs being picked up.")]
    //[SerializeField] AudioSource[] cigsPickUpSound;
    //[Tooltip("Sounds of cigs being put down.")]
    //[SerializeField] AudioSource[] cigsPutDownSound;
    [Tooltip("Sounds of fruit being picked up.")]
    [SerializeField] AudioSource[] fruitPickUpSound;
    [Tooltip("Sounds of fruit being put down.")]
    [SerializeField] AudioSource[] fruitPutDownSound;
    [Tooltip("Sounds of gas can being picked up.")]
    [SerializeField] AudioSource[] gasCanPickUpSound;
    [Tooltip("Sounds of gas can being put down.")]
    [SerializeField] AudioSource[] gasCanPutDownSound;
    //[Tooltip("Sounds of hot dog being picked up.")]
    //[SerializeField] AudioSource[] hotDogPickUpSound;
    //[Tooltip("Sounds of hot dog being put down.")]
    //[SerializeField] AudioSource[] hotDogPutDownSound;
    [Tooltip("Sounds of ice cream being picked up.")]
    [SerializeField] AudioSource[] iceCreamPickUpSound;
    [Tooltip("Sounds of ice cream being put down.")]
    [SerializeField] AudioSource[] iceCreamPutDownSound;
    [Tooltip("Sounds of nachos being picked up.")]
    [SerializeField] AudioSource[] nachosPickUpSound;
    [Tooltip("Sounds of nachos being put down.")]
    [SerializeField] AudioSource[] nachosPutDownSound;
    [Tooltip("Sounds of salad/sandwich being picked up.")]
    [SerializeField] AudioSource[] saladPickUpSound;
    [Tooltip("Sounds of salad/sandwich being put down.")]
    [SerializeField] AudioSource[] saladPutDownSound;
    [Tooltip("Sounds of soda cup being picked up.")]
    [SerializeField] AudioSource[] sodaCupPickUpSound;
    [Tooltip("Sounds of soda cup being put down.")]
    [SerializeField] AudioSource[] sodaCupPutDownSound;

    [Header("Phone Sounds")]
    [Tooltip("Text message sound.")]
    [SerializeField] AudioSource textMessageSound;
    [Tooltip("Phone unlock sound.")]
    [SerializeField] AudioSource unlockPhoneSound;
    [Tooltip("Phone lock sound.")]
    [SerializeField] AudioSource lockPhoneSound;

    [Header("Journal Sounds")]
    [Tooltip("Page turning sounds.")]
    [SerializeField] AudioSource[] pageTurnSound;
    [Tooltip("Book closing sound.")]
    [SerializeField] AudioSource bookClosingSound;

    [Header("UI Button Sounds")]
    [Tooltip("Button sounds.")]
    [SerializeField] AudioSource[] buttonSounds;

    [Header("Misc Sounds")]
    [Tooltip("Human footstep sounds.")]
    [SerializeField] AudioSource[] humanFootStepSound;
    [Tooltip("Sound for the door chime.")]
    [SerializeField] AudioSource doorbell;
    [Tooltip("Door closing sound.")]
    [SerializeField] AudioSource doorCloseSound;

    void Start()
    {
        //bgm.Play(); //looping?
        rain.Play();
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

    public void PlayDoorCloseSound()
    {
        doorCloseSound.Play();
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

    public void PlayAluminumCanUpSound()
    {
        int rand = Random.Range(0, 2);
        aluminumCanPickUpSound[rand].Play();
    }

    public void PlayAluminumCanDownSound()
    {
        int rand = Random.Range(0, 3);
        aluminumCanPutDownSound[rand].Play();
    }

    public void PlayGlassBottleUpSound()
    {
        int rand = Random.Range(0, 2);
        glassBottlePickUpSound[rand].Play();
    }

    public void PlayGlassBottleDownSound()
    {
        int rand = Random.Range(0, 2);
        glassBottlePutDownSound[rand].Play();
    }

    public void PlayWaterBottleUpSound()
    {
        int rand = Random.Range(0, 2);
        waterBottlePickUpSound[rand].Play();
    }

    public void PlayWaterBottleDownSound()
    {
        int rand = Random.Range(0, 2);
        waterBottlePutDownSound[rand].Play();
    }

    // FINISH EVERYTHING BELOW HERE
    public void PlayMoneyUpSound()
    {

    }

    public void PlayMoneyDownSound()
    {

    }

    public void PlayCandyUpSound()
    {

    }

    public void PlayCandyDownSound()
    {

    }

    public void PlayCardUpSound()
    {

    }

    public void PlayCardDownSound()
    {

    }

    public void PlayCarFluidUpSound()
    {

    }

    public void PlayCarFluidDownSound()
    {

    }

    public void PlayChargerUpSound()
    {

    }

    public void PlayChargerDownSound()
    {

    }

    public void PlayCigsUpSound()
    {

    }

    public void PlayCigsDownSound()
    {

    }

    public void PlayFruitUpSound()
    {

    }

    public void PlayFruitDownSound()
    {

    }

    public void PlayGasCanUpSound()
    {

    }

    public void PlayGasCanDownSound()
    {

    }

    public void PlayHotdogUpSound()
    {

    }

    public void PlayHotdogDownSound()
    {

    }

    public void PlayIceCreamUpSound()
    {

    }

    public void PlayIceCreamDownSound()
    {

    }

    public void PlayNachosUpSound()
    {

    }

    public void PlayNachosDownSound()
    {

    }

    public void PlaySaladUpSound()
    {

    }

    public void PlaySaladDownSound()
    {

    }

    public void PlaySodaCupUpSound()
    {

    }

    public void PlaySodaCupDownSound()
    {

    }

    // FINISH EVERYTHING ABOVE HERE

    public void PlayTextMessageSound()
    {
        textMessageSound.Play();
    }

    public void PlayPhoneUnlockSound()
    {
        unlockPhoneSound.Play();
    }

    public void PlayPhoneLockSound()
    {
        lockPhoneSound.Play();
    }

    public void PlayButtonSound(int index)
    {
        buttonSounds[index].Play();
    }

    public void PlayPageTurnSound()
    {
        int rand = Random.Range(0, 2);
        pageTurnSound[rand].Play();
    }

    public void PlayBookCloseSound()
    {
        bookClosingSound.Play();
    }
}