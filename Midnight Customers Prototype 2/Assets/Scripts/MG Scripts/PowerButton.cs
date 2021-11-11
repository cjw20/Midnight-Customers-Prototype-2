using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PowerButton : MonoBehaviour
{
    public bool onButton;
    public bool activated;

    [SerializeField] PowerButton[] targetSwitch; //buttons that this button affects
    Light2D thisLight;
    PowerGame powerGame;
    // Start is called before the first frame update
    void Start()
    {
        thisLight = this.gameObject.GetComponent<Light2D>();
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
        
        activated = !activated;
        thisLight.enabled = activated;
        powerGame.CheckFinish();
    }


}
