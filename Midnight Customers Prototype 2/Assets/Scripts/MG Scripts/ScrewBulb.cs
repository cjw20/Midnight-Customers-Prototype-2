using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrewBulb : MonoBehaviour
{
    // Fields
    [Header("Bulb Data")]
    [Tooltip("How many times the bulb needs to be clicked on.")]
    [SerializeField] int numberOfPresses;
    [Tooltip("Whether the bulb is new or not.")]
    [SerializeField] bool newBulb;
    [Tooltip("Whether the bulb is in the correct place or not.")]
    [SerializeField] bool inPlace;

    // References
    UnityEngine.Rendering.Universal.Light2D thisLight;
    LightChangeGame lightGame;
    SoundManager soundManager;
    [Header("Bulb Reference")]
    [Tooltip("The bulb that the player will drag to the empty slot.")]
    [SerializeField] GameObject dragBulb; //object that player will drag to empty slot

    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        thisLight = this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        lightGame = FindObjectOfType<LightChangeGame>();
    }

    private void OnMouseDown()
    {
        soundManager.PlayScrewLightbulbSound();
        if (newBulb)
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0); //simulates bulb being screwed in
        }
        else
        {
            this.gameObject.transform.position += new Vector3(0, -0.1f, 0);
        }

        numberOfPresses--;
        if(numberOfPresses <= 0)
        {
            if (newBulb)
            {
                thisLight.enabled = true;
                lightGame.Finish();
            }
            else
            {
                dragBulb.SetActive(true);
                Destroy(this.gameObject);
                    //gets rid of old bulb
            }
        }
    }
}