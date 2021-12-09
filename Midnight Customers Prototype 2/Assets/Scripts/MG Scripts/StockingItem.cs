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
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        stockingGame = FindObjectOfType<StockingGame>(); //better way to do this later?
        itemBox = FindObjectOfType<ItemBox>();
    }
    private void OnMouseDown()
    {
        if (!selected && !shelved)
        {
            if (itemID == "Cheez-O's")
            {
                soundManager.PlayChipsUpSound();
            }
            selected = true;
            stockingGame.SelectItem(this.gameObject);
            itemBox.SelectItem(this.gameObject);
            itemBox.CloseBox();
        }
    }
    /* private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Shelf" && !other.gameObject.GetComponent<Shelf>().stocked)
        {
            shelved = true;
            Destroy(GetComponent<ClickDrag>()); //removes ability for player to move item?
            this.transform.position = other.gameObject.GetComponent<Shelf>().target.position;
            stockingGame.ShelfItem();
            Debug.Log(">>>");
            //compare id with shelf id to see if correct item was placed. Affects preformance review?
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shelf") && !collision.gameObject.GetComponent<Shelf>().stocked)
        {
            if (itemID == "Cheez-O's")
            {
                soundManager.PlayChipsDownSound();
            }
            shelved = true;
            Destroy(GetComponent<ClickDrag>()); //removes ability for player to move item?
            this.transform.position = collision.gameObject.GetComponent<Shelf>().target.position;
            collision.gameObject.GetComponent<Shelf>().stocked = true;
            stockingGame.ShelfItem();
            Debug.Log(">>>");
            //compare id with shelf id to see if correct item was placed. Affects preformance review?
        }
    }
}