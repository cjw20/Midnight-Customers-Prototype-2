using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGame : MonoBehaviour
{
    [SerializeField] PowerButton[] offButtons;
    [SerializeField] PowerButton[] onButtons;

    MiniGameControl mgControl;
    // Start is called before the first frame update
    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
