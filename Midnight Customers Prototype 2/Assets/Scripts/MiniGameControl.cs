using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    public Transform cameraPosition;
    MiniGameTrigger currentTrigger;

    GameObject currentGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMiniGame(GameObject miniGame, MiniGameTrigger trigger)
    {
        currentGame = Instantiate(miniGame, cameraPosition);
        currentTrigger = trigger;
    }

    public void EndMiniGame()
    {
        currentTrigger.EndMiniGame();
        
        currentGame = null;
        
    }
}
