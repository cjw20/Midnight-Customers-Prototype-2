using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingItem : MonoBehaviour
{
    StockingGame stockingGame;
    ItemBox itemBox;
    bool selected = false;

    private void Start()
    {
        stockingGame = FindObjectOfType<StockingGame>(); //better way to do this later?
        itemBox = FindObjectOfType<ItemBox>();
    }
    private void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
            stockingGame.SelectItem(this.gameObject);
            itemBox.SelectItem(this.gameObject);
            itemBox.CloseBox();

            
        }
        
        
    }
}
