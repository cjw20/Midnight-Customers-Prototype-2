using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    // Fields

    // References
    Transform cameraPosition;
    MiniGameTrigger currentTrigger;
    GameObject currentGame;
    [Header("References")]
    [Tooltip("Reference to a TaskSpawner class instance.")]
    [SerializeField] TaskSpawner taskSpawner;
    [Tooltip("Reference to a SoundManager class instance.")]
    [SerializeField] SoundManager soundManager;

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