using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGame : MonoBehaviour
{
    [SerializeField] PowerButton[] offButtons;
    [SerializeField] PowerButton[] onButtons;

    MiniGameControl mgControl;
void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
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
            mgControl.EndMiniGame();
            Destroy(this.gameObject);
        }
    }
}
