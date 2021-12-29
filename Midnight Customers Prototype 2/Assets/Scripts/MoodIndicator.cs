using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodIndicator : MonoBehaviour
{
    // Fields

    // References
    SpriteRenderer spriteRenderer;
    [Header("Sprites")]
    [Tooltip("Sprite for the happy mood.")]
    [SerializeField] Sprite happySprite;
    [Tooltip("Sprite for the sad mood.")]
    [SerializeField] Sprite sadSprite;
    [Tooltip("Sprite for the angry mood.")]
    [SerializeField] Sprite angrySprite;
    [Tooltip("Sprite for the pissed mood.")]
    [SerializeField] Sprite pissedSprite;

    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetMood(string mood)
    {
        switch (mood)
        {
            case "happy":
                spriteRenderer.sprite = happySprite;
                break;
            case "sad":
                spriteRenderer.sprite = sadSprite;
                break;
            case "angry":
                spriteRenderer.sprite = angrySprite;
                break;
            case "pissed":
                spriteRenderer.sprite = pissedSprite;
                break;
            default:
                spriteRenderer.sprite = happySprite;  //default to happy just in case
                break;
        }
    }
}