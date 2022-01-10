using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteController : MonoBehaviour
{
    // Fields

    // References
    Coroutine lastCoroutine;
    [Header("Sprites")]
    [Tooltip("Reference to a Sprite Renderer.")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Tooltip("Reference to the happy emote sprite.")]
    [SerializeField] Sprite happyEmote;
    [Tooltip("Reference to the sad emote sprite.")]
    [SerializeField] Sprite sadEmote;
    [Tooltip("Reference to the angry emote sprite.")]
    [SerializeField] Sprite angryEmote;

    public void React(string emotion)
    {
        if(lastCoroutine != null)
        {
            StopCoroutine(lastCoroutine);
        }
        switch (emotion)
        {
            case "Happy":
                spriteRenderer.sprite = happyEmote;
                break;
            case "Angry":
                spriteRenderer.sprite = angryEmote;
                break;
            case "Sad":
                spriteRenderer.sprite = sadEmote;
                break;
            default:
                break;
        }
        lastCoroutine = StartCoroutine(HideReaction());
    }

    IEnumerator HideReaction()
    {
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = null;
        lastCoroutine = null;
        yield break;
    }
}