using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingGame : MonoBehaviour
{
    public GameObject heldItem;
    int remainingShelves;
    MiniGameControl mgControl;

    // Start is called before the first frame update
    void Start()
    {
        remainingShelves = 3; //have shelves tell this how many if this number can change
        mgControl = FindObjectOfType<MiniGameControl>();
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