using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TaskSpawner : MonoBehaviour
{
    [SerializeField] GameObject mopTrigger;
    
    public List<GameObject> mopSpawns;
    List<int> usedSpawns = new List<int>();

    

    public void NewDayTasks()
    {
        //logic to decide which tasks to choose here
        List<int> usedSpawns = new List<int>(); //clears used spawns for tasks
        SpawnMopTask(2);
    }

    void SpawnMopTask(int amount)
    {
        int random = Random.Range(0, mopSpawns.Count);
        for(int i = 0; i < amount; i++)
        {
            Instantiate(mopTrigger, mopSpawns[random].transform);
            usedSpawns.Add(random);
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
}
