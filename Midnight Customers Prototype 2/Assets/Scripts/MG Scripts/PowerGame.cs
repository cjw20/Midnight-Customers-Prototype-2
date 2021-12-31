using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGame : MonoBehaviour
{
    // Fields

    // References
    MiniGameControl mgControl;
    LightManager lightManager;
    [Header("Power Buttons")]
    [Tooltip("Off buttons on the breaker box.")]
    [SerializeField] PowerButton[] offButtons;
    [Tooltip("On buttons on the breaker box.")]
    [SerializeField] PowerButton[] onButtons;

    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
        lightManager = FindObjectOfType<LightManager>();
    }

    public void CheckFinish()
    {
        bool finished = true;
        foreach(PowerButton button in onButtons)
        {
            if (!button.activated)
            {
                finished = false;
            }
        }

        if (finished)
        {
            lightManager.RestorePower();
            mgControl.EndMiniGame();
            Destroy(this.gameObject);
        }
    }
}