using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    public bool playerReady; //true when player is standing behind register
    public bool customerReady; //true when customer is standing in front of register, ready to check out

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerReady()
    {
        playerReady = true;
    }

    public void UnreadyPlayer()
    {
        playerReady = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerReady = false;
        }
    }
}
