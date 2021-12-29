using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TaskSpawner : MonoBehaviour
{
    // Fields
    [Header("Task Management")]
    [Tooltip("Number of spawned tasks that are unfinished.")]
    public int unfinishedTasks;
    List<int> usedSpawns = new List<int>();
    List<GameObject> tasksInStore = new List<GameObject>();

    // References
    [Header("Task References")]
    [Tooltip("Location to trigger the mop minigame.")]
    [SerializeField] GameObject mopTrigger;
    [Tooltip("Location to trigger the stocking minigame.")]
    [SerializeField] GameObject shelfTrigger; //maybe make array once variations are added
    [Tooltip("List of spawn points for the mop minigame.")]
    public List<GameObject> mopSpawns; //make transform later
    [Tooltip("List of spawn points for the stocking minigame.")]
    public List<Transform> shelfSpawns;
    
    public void NewDayTasks()
    {
        //logic to decide which tasks to choose here
        List<int> usedSpawns = new List<int>(); //clears used spawns for tasks

        //spawn 1-2 of each task each day

        //eventally make it so tasks spawn throughout day instead of all at once
        int random = Random.Range(1, 2);
        SpawnMopTask(random);
        random = Random.Range(1, 2); 
        SpawnShelfTask(random);
        //commented ^ out for gdex build because of dumb bug and no visual assets
    }

    void SpawnMopTask(int amount)
    {
        int random = Random.Range(0, mopSpawns.Count);
        for(int i = 0; i < amount; i++)
        {
            GameObject task = Instantiate(mopTrigger, mopSpawns[random].transform);
            tasksInStore.Add(task);
            usedSpawns.Add(random);
            unfinishedTasks++;
            random = Random.Range(0, mopSpawns.Count);

            int j = -1;
            while (usedSpawns.Contains(random)) //makes sure tasks dont spawn on each other
            {
                random++;
                j++;
                if(random > mopSpawns.Count - 1)
                {
                    random = 0; //makes sure random doesnt go outside list
                }

                if(j >= usedSpawns.Count)
                {
                    break;
                }
                //probably should find different way to do this later
            }
        }
    }

    void SpawnShelfTask(int amount)
    {
        //same as mop logic for now
        int random = Random.Range(0, shelfSpawns.Count);
        for (int i = 0; i < amount; i++)
        {
            GameObject task = Instantiate(shelfTrigger, shelfSpawns[random]);
            tasksInStore.Add(task);
            usedSpawns.Add(random);
            unfinishedTasks++;
            random = Random.Range(0, shelfSpawns.Count);

            int j = -1;
            while (usedSpawns.Contains(random)) //makes sure tasks dont spawn on each other
            {
                random++;
                j++;
                if (random > shelfSpawns.Count - 1)
                {
                    random = 0; //makes sure random doesnt go outside list
                }

                if (j >= usedSpawns.Count)
                {
                    break;
                }
                //probably should find different way to do this later
            }
        }
    }

    public void ClearTasks()
    {
        foreach(GameObject task in tasksInStore)
        {
            Destroy(task);
        }
        tasksInStore.Clear();
        ManualClearTasks();
    }
    public void ManualClearTasks(){
        GameObject[] gameTriggers = GameObject.FindGameObjectsWithTag("Minigame");
        foreach(GameObject mg in gameTriggers){
            unfinishedTasks++;
            Destroy(mg);
        }
    }
}