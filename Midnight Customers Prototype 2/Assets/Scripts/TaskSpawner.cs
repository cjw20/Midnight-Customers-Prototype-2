using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TaskSpawner : MonoBehaviour
{
    [SerializeField] GameObject mopTrigger;
    [SerializeField] GameObject shelfTrigger; //maybe make array once variations are added
    
    public List<GameObject> mopSpawns; //make transform later
    public List<Transform> shelfSpawns;
    List<int> usedSpawns = new List<int>();
    List<GameObject> tasksInStore = new List<GameObject>();
    public int unfinishedTasks; //number of spawned tasks that are unfinished

    

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
    }
}
