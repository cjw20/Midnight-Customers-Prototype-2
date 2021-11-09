using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    Transform cameraPosition;
    MiniGameTrigger currentTrigger;

    [SerializeField] TaskSpawner taskSpawner;
    [SerializeField] SoundManager soundManager;

    GameObject currentGame;
   

    public void LoadMiniGame(GameObject miniGame, MiniGameTrigger trigger)
    {
        currentGame = Instantiate(miniGame, this.gameObject.transform);
        cameraPosition = Camera.main.transform;
        Camera.main.transform.position = this.transform.position;
        currentTrigger = trigger;
    }

    public void EndMiniGame()
    {
        Camera.main.transform.position = new Vector3(0 , -1, -10);
        currentTrigger.EndMiniGame();
        taskSpawner.unfinishedTasks--; 
        currentGame = null;
        soundManager.StopSweepingSound();
        
    }
}