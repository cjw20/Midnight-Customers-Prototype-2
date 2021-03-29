using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGame : MonoBehaviour
{
    public GameObject[] cleanableObjects;
    int remainingObjects;
    MiniGameControl mgControl;

    // Start is called before the first frame update
    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
        remainingObjects = cleanableObjects.Length;
    }

    public void CleanedObject()
    {
        remainingObjects--;
        if(remainingObjects < 1)
        {
            mgControl.EndMiniGame();
            Destroy(this.gameObject);
        }
    }
}
