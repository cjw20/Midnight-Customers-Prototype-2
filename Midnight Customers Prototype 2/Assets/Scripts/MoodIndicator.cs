using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodIndicator : MonoBehaviour
{
    [SerializeField] Sprite happySprite;
    [SerializeField] Sprite sadSprite;
    [SerializeField] Sprite angrySprite;
    [SerializeField] Sprite pissedSprite;

    SpriteRenderer spriteRenderer;
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
