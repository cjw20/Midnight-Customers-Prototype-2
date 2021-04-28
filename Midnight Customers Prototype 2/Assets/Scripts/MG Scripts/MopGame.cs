using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGame : MonoBehaviour
{
    public GameObject[] cleanableObjects;
    int remainingObjects;
    MiniGameControl mgControl;
    FMOD.Studio.EventInstance mopSound;

    // Start is called before the first frame update
    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
        remainingObjects = cleanableObjects.Length;
        mopSound = FMODUnity.RuntimeManager.CreateInstance("event:/Tasks/mop");
    }

    public void CleanedObject()
    {
        mopSound.start();
        remainingObjects--;
        if(remainingObjects < 1)
        {
            mgControl.EndMiniGame();
            Destroy(this.gameObject);
        }
    }
}
