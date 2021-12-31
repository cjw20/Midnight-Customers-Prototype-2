using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopGame : MonoBehaviour
{
    // Fields
    //public int numObjects = Random.Range(2,6)
    //instantiate number of Objects at start
    //include two different prefab references
    int remainingObjects;

    // References
    GameObject[] cleanableObjects;
    MiniGameControl mgControl;
    [Header("Dirt Spots")]
    [Tooltip("First dirt spot.")]
    public GameObject dirt1; //dependent on prefab reference in-editor
    [Tooltip("Second dirt spot.")]
    public GameObject dirt2; //dependent on prefab reference in-editor
    

    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
        int startingNumber = Random.Range(2,6);
        cleanableObjects = new GameObject[startingNumber]; //double check for accurate array length
        for(int i = 0; i < startingNumber; i++){
            Vector3 positionGenerator = new Vector3(Random.Range(-8f, 8f),Random.Range(-4f, 4f), 10);
            cleanableObjects[i] = Instantiate(dirt1, positionGenerator + mgControl.transform.position, Quaternion.identity, this.gameObject.transform);
        }
        remainingObjects = cleanableObjects.Length;
    }

    public void CleanedObject()
    {
        remainingObjects--;
        if(remainingObjects < 1)
        {
            mgControl.EndMiniGame();
            Destroy(this.gameObject); //woah thats dark
        }
    }
}