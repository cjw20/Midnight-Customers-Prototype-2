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

    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        playerLastFramePosition = transform.position;
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
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical"); //movement using wasd or arrow keys
        playerLastFramePosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (moveable)
        {
            body.MovePosition(body.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}