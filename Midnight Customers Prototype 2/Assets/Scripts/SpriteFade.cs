using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    //Works like Fade script but uses sprites instead of ui images
    // Fields
    bool fadeIN;
    bool fadeOUT;
    float currentAlpha;
    float duration;
    float passedTime;

    // References
    public SpriteRenderer thisSprite;
    Color startingColor;
    [Header("Fade Color")]
    [Tooltip("Color for the fade screen.")]
    public Color newColor;

    void Start()
    {
        thisSprite = gameObject.GetComponent<SpriteRenderer>();
        startingColor = thisSprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIN)
        {
            passedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(0, 1, passedTime / duration);
            newColor = new Color(startingColor.r, startingColor.g, startingColor.b, currentAlpha);
            thisSprite.color = newColor;

            if (currentAlpha == 1)
            {
                fadeIN = false;
                passedTime = 0;
            }
        }

        if (fadeOUT)
        {
            passedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(1, 0, passedTime / duration);
            newColor = new Color(startingColor.r, startingColor.g, startingColor.b, currentAlpha);
            thisSprite.color = newColor;

            if (currentAlpha == 0)
            {
                fadeOUT = false;
                passedTime = 0;
            }
        }
    }

    public void FadeIn(float time)
    {
        duration = time;
        fadeIN = true;
    }

    public void FadeOut(float time)
    {
        duration = time;
        fadeOUT = true;
    }
}
