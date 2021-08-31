using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingItem : MonoBehaviour
{
    StockingGame stockingGame;
    ItemBox itemBox;
    bool selected;
    bool shelved;
    public string itemID;
    private void Start()
    {
        stockingGame = FindObjectOfType<StockingGame>(); //better way to do this later?
        itemBox = FindObjectOfType<ItemBox>();
    }
    private void OnMouseDown()
    {
        if (!selected && !shelved)
        {
            selected = true;
            stockingGame.SelectItem(this.gameObject);
            itemBox.SelectItem(this.gameObject);
            itemBox.CloseBox();

            
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shelf")
        {
            shelved = true;
            Destroy(GetComponent<ClickDrag>()); //removes ability for player to move item?
            this.transform.position = other.gameObject.GetComponent<Shelf>().target.position;

            //compare id with shelf id to see if correct item was placed. Affects preformance review?
        }
    }


   
}
