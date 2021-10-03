using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLayering : MonoBehaviour
{
    public int targetLayer;
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Customer"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = targetLayer;
        }
    }
}
