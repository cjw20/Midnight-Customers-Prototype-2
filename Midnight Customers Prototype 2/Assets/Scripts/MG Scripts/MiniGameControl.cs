using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    public Transform cameraPosition;
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
        currentTrigger.EndMiniGame();
        taskSpawner.unfinishedTasks--; 
        currentGame = null;
        soundManager.StopSweepingSound();
        Camera.main.transform.position = cameraPosition.position;
    }
}