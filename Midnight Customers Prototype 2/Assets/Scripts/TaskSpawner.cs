using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TaskSpawner : MonoBehaviour
{
    [SerializeField] GameObject mopTrigger;
    
    public List<GameObject> mopSpawns;
    Transform spawn;

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
        int random = Random.Range(1, 5);
        for(int i = 0; i < amount; i++)
        {
            spawn = GameObject.Find("Mop " + random.ToString()).transform;
            //Debug.Log(mopSpawns.Count);
            Instantiate(mopTrigger, spawn);
            random = Random.Range(1, 5);
        }
    }
}
