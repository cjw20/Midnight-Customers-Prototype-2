using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementDirection;
    Rigidbody2D body;
    public float moveSpeed;
    public bool moveable = true;

    FMOD.Studio.EventInstance playerFootsteps;

    // Start is called before the first frame update
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        playerFootsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps/player-feet");
        playerFootsteps.start();
    }

    // Update is called once per frame
    void Update()
    {
        
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical"); //movement using wasd or arrow keys

        playerFootsteps.setParameterByName("Movement", Mathf.Abs(movementDirection.x) + Mathf.Abs(movementDirection.y));
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
