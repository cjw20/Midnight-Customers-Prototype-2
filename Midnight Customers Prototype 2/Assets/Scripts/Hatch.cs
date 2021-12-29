using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    // Fields
    bool found;
    bool inRange;

    // References
    private PlayerInput playerInput; //asset that has player controls
    [Header("References")]
    [Tooltip("Reference to a HatchStoryBeat class instance.")]
    [SerializeField] HatchStoryBeat story;

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

    void Update()
    {
        if (playerInput.Store.Interact.triggered)
        {
            if (inRange && !found)
            {
                found = true;
                story.FoundHatch();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}