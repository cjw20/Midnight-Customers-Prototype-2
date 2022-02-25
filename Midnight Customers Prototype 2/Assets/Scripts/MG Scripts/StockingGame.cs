using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingGame : MonoBehaviour
{
    // Fields
    int remainingShelves;

    // References
    MiniGameControl mgControl;
    [Header("Game Object References")]
    [Tooltip("The currently held item.")]
    public GameObject heldItem;

    public Sprite[] sprites;

    Sprite selected;

    ItemBox childBox;
    public 

    SpriteRenderer[] prestocked;

    void Start()
    {
        remainingShelves = 3; //have shelves tell this how many if this number can change
        mgControl = FindObjectOfType<MiniGameControl>();
        int i = Random.Range(0, sprites.Length - 1);
        selected = sprites[i];
        childBox = GetComponentInChildren<ItemBox>();
        childBox.UpdateItems(selected);
        prestocked = transform.GetChild(4).GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sr in prestocked){
            sr.sprite = selected;
        }
    }

    public void SelectItem(GameObject item)
    {
        heldItem = item;
        heldItem.transform.parent = this.gameObject.transform; 
    }
     
    public void ShelfItem()
    {
        remainingShelves--;
        if(remainingShelves <= 0)
        {
            mgControl.EndMiniGame();
            Destroy(this.gameObject); //add a delay to this to make it less jarring
        }
    }
}