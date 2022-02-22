using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    // Fields
    [Header("Box Data")]
    [Tooltip("Whether the box is open or not.")]
    public bool boxOpen;

    // References
    [Header("References")]
    [Tooltip("The opened box object.")]
    public GameObject openedBox;
    [Tooltip("Array of items in the box.")]
    public GameObject[] itemsInBox;
    [Tooltip("Locations for items to be instantiated in the box.")]
    public Transform[] boxSpawns;
    [Tooltip("Items that have been spawned.")]
    public List<GameObject> spawnedItems;
    SpriteRenderer sprite;

    void Start()
    {
        if(gameObject.TryGetComponent(out SpriteRenderer reference)){
            sprite = reference; 
        }
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

    void OnMouseOver()
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        }

    void OnMouseExit()
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
}