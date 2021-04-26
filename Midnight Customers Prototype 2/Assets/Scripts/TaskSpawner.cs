using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    [SerializeField] GameObject mopTrigger;
    [SerializeField] Transform[] mopLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDayTasks()
    {
        //logic to decide which tasks to choose here

        SpawnMopTask(2);
    }

    void SpawnMopTask(int amount)
    {
        int random = Random.Range(0, mopLocations.Length - 1);
        for(int i = 0; i < amount; i++)
        {
            Instantiate(mopTrigger, mopLocations[random]);
            random = Random.Range(0, mopLocations.Length);
        }
    }
}
