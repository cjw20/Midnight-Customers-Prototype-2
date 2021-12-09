using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ScrewBulb : MonoBehaviour
{
    [SerializeField] int numberOfPresses; //how many time bulb needs to be clicked on
    [SerializeField] bool newBulb; //true if new

    [SerializeField] bool inPlace;

    Light2D thisLight;
    LightChangeGame lightGame;
    SoundManager soundManager;

    [SerializeField] GameObject dragBulb; //object that player will drag to empty slot

    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        thisLight = this.gameObject.GetComponent<Light2D>();
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