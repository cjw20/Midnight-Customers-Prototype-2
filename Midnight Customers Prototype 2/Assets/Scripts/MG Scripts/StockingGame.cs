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
        mgControl = FindObjectOfType<MiniGameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
