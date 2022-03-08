using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingItem : MonoBehaviour
{
    // Fields
    bool selected;
    bool shelved;
    [Tooltip("Item Type")]
    public int itemType;

    // References
    StockingGame stockingGame;
    ItemBox itemBox;
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
            if (itemType == 0 || itemType == 1)
            {
                // Play the beer bottle sound
                soundManager.PlayGlassBottleUpSound();
            }
            else if (itemType == 2 || itemType == 3 || itemType == 4)
            {
                // Play the candybar sound
                soundManager.PlayChipsUpSound();
                // REPLACE WITH NEW SOUND
            }
            else if (itemType == 5)
            {
                // Play carfluidbottle sound
                soundManager.PlayWaterBottleUpSound();
                // REPLACE WITH NEW SOUND
            }
            else if (itemType == 6)
            {
                // Play charger sound
            }
            else if (itemType == 7 || itemType == 8 || itemType == 9)
            {
                // Play chips bag sound
                soundManager.PlayChipsUpSound();
            }
            else if (itemType == 10)
            {
                // Play coffee bottle sound
                soundManager.PlayGlassBottleUpSound();
            }
            else if (itemType == 11 || itemType == 12 || itemType == 13)
            {
                // Play energy sound
                soundManager.PlayAluminumCanUpSound();
            }
            else if (itemType == 14 || itemType == 15 || itemType == 16)
            {
                // Play fruit sound
            }
            else if (itemType == 17)
            {
                // Play gasoline sound
            }
            else if (itemType == 18)
            {
                // Play nacho sound
            }
            else if (itemType == 19 || itemType == 20)
            {
                // Play salad sound
            }
            else if (itemType == 21 || itemType == 22)
            {
                // Play sandwich sound
            }
            else if (itemType == 23 || itemType == 24 || itemType == 25)
            {
                // Play soda sound
                soundManager.PlayAluminumCanUpSound();
            }
            else if (itemType == 26)
            {
                // Play soda cup sound
            }
            else if (itemType == 27)
            {
                // Play tea bottle sound
                soundManager.PlayWaterBottleUpSound();
            }
            else if (itemType == 28)
            {
                // Play water bottle sound
                soundManager.PlayWaterBottleUpSound();
            }
            else
            {
                // Play some default item movement sound
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
            if (itemType == 0 || itemType == 1)
            {
                // Play the beer bottle sound
                soundManager.PlayGlassBottleDownSound();
            }
            else if (itemType == 2 || itemType == 3 || itemType == 4)
            {
                // Play the candybar sound
                soundManager.PlayChipsDownSound();
                // REPLACE WITH NEW SOUND
            }
            else if (itemType == 5)
            {
                // Play carfluidbottle sound
                soundManager.PlayWaterBottleDownSound();
                // REPLACE WITH NEW SOUND
            }
            else if (itemType == 6)
            {
                // Play charger sound
            }
            else if (itemType == 7 || itemType == 8 || itemType == 9)
            {
                // Play chips bag sound
                soundManager.PlayChipsDownSound();
            }
            else if (itemType == 10)
            {
                // Play coffee bottle sound
                soundManager.PlayGlassBottleDownSound();
            }
            else if (itemType == 11 || itemType == 12 || itemType == 13)
            {
                // Play energy sound
                soundManager.PlayAluminumCanDownSound();
            }
            else if (itemType == 14 || itemType == 15 || itemType == 16)
            {
                // Play fruit sound
            }
            else if (itemType == 17)
            {
                // Play gasoline sound
            }
            else if (itemType == 18)
            {
                // Play nacho sound
            }
            else if (itemType == 19 || itemType == 20)
            {
                // Play salad sound
            }
            else if (itemType == 21 || itemType == 22)
            {
                // Play sandwich sound
            }
            else if (itemType == 23 || itemType == 24 || itemType == 25)
            {
                // Play soda sound
                soundManager.PlayAluminumCanDownSound();
            }
            else if (itemType == 26)
            {
                // Play soda cup sound
            }
            else if (itemType == 27)
            {
                // Play tea bottle sound
                soundManager.PlayWaterBottleDownSound();
            }
            else if (itemType == 28)
            {
                // Play water bottle sound
                soundManager.PlayWaterBottleDownSound();
            }
            else
            {
                // Play some default item movement sound
            }
            shelved = true;
            Destroy(GetComponent<ClickDrag>()); //removes ability for player to move item?
            this.transform.position = collision.gameObject.GetComponent<Shelf>().target.position;
            collision.gameObject.GetComponent<Shelf>().stocked = true;
            stockingGame.ShelfItem();
        }
    }
}