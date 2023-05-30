using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerButton : MonoBehaviour
{
    // Fields
    [Header("Power Data")]
    [Tooltip("Whether the on button is lit or not.")]
    public bool onButton;
    [Tooltip("Whether the button is active or not.")]
    public bool activated;

    // References
    UnityEngine.Rendering.Universal.Light2D thisLight;
    PowerGame powerGame;
    SoundManager soundManager;
    [Header("Switches")]
    [Tooltip("Array of PowerButtons that this button affects.")]
    [SerializeField] PowerButton[] targetSwitch;

    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        thisLight = this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        powerGame = FindObjectOfType<PowerGame>();
    }

    void OnMouseDown()
    {
        if (!activated)
        {
            return;
            //so you cant press an unactivated button, works more like switch for when art is made
        }
        foreach (PowerButton button in targetSwitch)
        {
            button.ToggleButton();
        }
    }

    public void ToggleButton()
    {
        soundManager.PlayBreakerSwitchSound();
        activated = !activated;
        thisLight.enabled = activated;
        powerGame.CheckFinish();
    }
}