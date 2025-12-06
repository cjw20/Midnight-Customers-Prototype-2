using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Fields
    Vector2 movementDirection;
    Rigidbody2D body;
    [Header("Movement Data")]
    [Tooltip("Movement speed.")]
    public float moveSpeed;
    [Tooltip("Toggle if player is movable.")]
    public bool moveable = true;

    // References
    private PlayerInput playerInput; //asset that has player controls
    Animator animator;
    SpriteRenderer spriteRenderer;
    [Header("Trigger/Interaction References")]
    [Tooltip("Reference to a CheckoutTrigger class instance.")]
    public CheckoutTrigger checkoutTrigger;
    [Tooltip("Reference to a MiniGameTrigger class instance.")]
    public MiniGameTrigger nearbyMG;
    [Tooltip("Reference to an Interactable class instance.")]
    public Interactable nearbyInteractable;

    [Header("Object References")]
    [Tooltip("No idea what this does.")]
    public GameObject Epopup; //!
    [Tooltip("No idea what this does.")]
    public GameObject Qpopup; //?
    [Tooltip("Reference to the player's flashlight game object.")]
    [SerializeField] GameObject flashLight;

    [Header("Audio")]
    [Tooltip("Reference to a SoundManager class instance.")]
    [SerializeField] SoundManager soundManager;
    
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
        animator = this.gameObject.GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if(movementDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void PlayFootStep()
    {
        soundManager.PlayPlayerFootstepSounds();
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