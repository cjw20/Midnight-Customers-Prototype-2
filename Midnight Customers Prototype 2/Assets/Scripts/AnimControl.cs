using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    //OLD DONT USE THIS

    // Fields
    [Header("Data")]
    [Tooltip("Velocity of this object.")]
    public Vector2 velocity;

    // References
    Rigidbody2D body;
    Animator animator;
    
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        velocity = body.velocity;
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);

        if(Mathf.Abs(velocity.x) > 0 || Mathf.Abs(velocity.y) > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            //probably better way to do this, but oh well
        }
    }
}