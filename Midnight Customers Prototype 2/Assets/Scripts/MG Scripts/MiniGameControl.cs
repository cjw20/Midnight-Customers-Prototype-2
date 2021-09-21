using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    public Transform cameraPosition;
    MiniGameTrigger currentTrigger;

    [SerializeField] TaskSpawner taskSpawner;

    GameObject currentGame;
   

    public void LoadMiniGame(GameObject miniGame, MiniGameTrigger trigger)
    {
        currentGame = Instantiate(miniGame, cameraPosition);
        currentTrigger = trigger;
    }

    public void EndMiniGame()
    {
        currentTrigger.EndMiniGame();
        taskSpawner.unfinishedTasks--; 
        currentGame = null;
        
    }
}
