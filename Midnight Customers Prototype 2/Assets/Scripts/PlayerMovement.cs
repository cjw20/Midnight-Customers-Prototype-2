using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementDirection;
    Rigidbody2D body;
    public float moveSpeed;
    public bool moveable = true;
    private Vector2 playerLastFramePosition;
    [SerializeField] float stepDistance;
    private float stepTimer = 0f;
    private bool timerRunning = false;

    [SerializeField] SoundManager soundManager;

    public GameObject Epopup; //!
    public GameObject Qpopup; //?

    [SerializeField] GameObject flashLight;

    public MiniGameTrigger nearbyMG;
    public Interactable nearbyInteractable;
    public CheckoutTrigger checkoutTrigger;

    private PlayerInput playerInput; //asset that has player controls
    Animator animator;

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
    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        playerLastFramePosition = transform.position;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDistance)
            {
                timerRunning = false;
                stepTimer = 0f;
            }
        }
        if (Vector2.Distance(playerLastFramePosition, transform.position) > 0)
        {
            if (!timerRunning)
            {
                soundManager.PlayPlayerFootstepSounds();
                timerRunning = true;
            }
        }
        //movementDirection.x = Input.GetAxisRaw("Horizontal");
        //movementDirection.y = Input.GetAxisRaw("Vertical"); //movement using wasd or arrow keys 
        //old input system above

        movementDirection = playerInput.Store.Move.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);

        if(movementDirection.x == 0 && movementDirection.y == 0)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", true);
        }
        playerLastFramePosition = transform.position;


       
    }


    public void Interact()
    {
        if (!moveable)
            return; // so interactions dont overlap

        if(checkoutTrigger != null)
        {
            checkoutTrigger.TriggerCheckout();
        }
        else if(nearbyMG != null)
        {
            nearbyMG.TriggerMiniGame();
        }
        else if(nearbyInteractable != null)
        {
            nearbyInteractable.TriggerInteractable();
        }
    }

    private void FixedUpdate()
    {
        if (moveable)
        {
            body.MovePosition(body.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

  
}