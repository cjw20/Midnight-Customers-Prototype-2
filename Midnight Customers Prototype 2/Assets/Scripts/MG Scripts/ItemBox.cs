using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public bool boxOpen;
    public GameObject openedBox;

    public GameObject[] itemsInBox;
    public Transform[] boxSpawns; //where items are to be instantiated in box

    public List<GameObject> spawnedItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {

        if (!boxOpen)
        {
            OpenBox();
        }
        //open up box to pick item
    }

    public void SelectItem(GameObject item)
    {
        spawnedItems.Remove(item);
        //prevents item from being deleted when box closes
    }

    void OpenBox()
    {
        boxOpen = true;
        openedBox.SetActive(true);
        SpawnItems();
        //display items
    }

    public void CloseBox()
    {
        boxOpen = false;
        foreach(GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        openedBox.SetActive(false);
    }

    void SpawnItems()
    {
        spawnedItems = new List<GameObject>();
        //spawns items in box each time it is opened;
        int i = 0;
        foreach(GameObject item in itemsInBox)
        {
            GameObject newItem = Instantiate(item, boxSpawns[i]);
            spawnedItems.Add(newItem);
            i++;
        }
    }
}