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

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Hide());
        //spriteRenderer.color = new Color(1f, 1f, 1f, 1f); //resets sprite from fade out
        //HideEmote();
    }

    public void SetMood(string mood)
    {
        switch (mood)
        {
            case "happy":
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = happySprite;
                StartCoroutine(Hide());
                //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                //HideEmote();
                break;
            case "sad":
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = sadSprite;
                StartCoroutine(Hide());
                //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                //HideEmote();
                break;
            case "angry":
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = angrySprite;
                StartCoroutine(Hide());
                //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                //HideEmote();
                break;
            case "pissed":
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = pissedSprite;
                StartCoroutine(Hide());
                //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                //HideEmote();
                break;
            default:
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = happySprite;  //default to happy just in case
                StartCoroutine(Hide());
                //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                //HideEmote();
                break;
        }
    }

    void HideEmote()
    {
        SpriteFade fade = this.gameObject.AddComponent<SpriteFade>();
        fade.FadeOut(1f);
        Destroy(fade);
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(3f);
        spriteRenderer.enabled = false;
        yield break;
    }
}