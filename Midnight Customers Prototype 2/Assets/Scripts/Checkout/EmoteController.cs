using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite happyEmote;
    [SerializeField] Sprite sadEmote;
    [SerializeField] Sprite angryEmote;

    Coroutine lastCoroutine;

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