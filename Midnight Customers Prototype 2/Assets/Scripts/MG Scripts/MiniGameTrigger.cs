using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject miniGame; //minigame to load
    MiniGameControl mgControl;
    PlayerMovement playerMove;
    //bool playerReady;
    //bool inGame;
    // Start is called before the first frame update

    private PlayerInput playerInput; //asset that has player controls
    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Start()
    {
        mgControl = FindObjectOfType<MiniGameControl>();
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (playerInput.Store.Interact.triggered)
        {
            if (playerReady && !inGame)
            {
                playerMove.moveable = false;
                inGame = true;
                mgControl.LoadMiniGame(miniGame, this);
            }
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerReady = true;
            playerMove = collision.gameObject.GetComponent<PlayerMovement>();
            playerMove.Epopup.SetActive(true);
            playerMove.nearbyMG = this;
        }

        
    }

    public void TriggerMiniGame()
    {
        playerMove.moveable = false;
        //inGame = true;
        mgControl.LoadMiniGame(miniGame, this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerReady = false;
            playerMove.Epopup.SetActive(false);
            playerMove.nearbyMG = null;
        }

       
    }

    public void EndMiniGame()
    {
        playerMove.moveable = true;
        Destroy(this.gameObject);
    }
}
