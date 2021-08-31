using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    
    bool fadeIN;
    bool fadeOUT;

    float currentAlpha;
    Image thisSprite;
    Color startingColor;
    public Color newColor;

    float duration;
    float passedTime;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = gameObject.GetComponent<Image>();
        startingColor = thisSprite.color;

        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(fadeIN)
        {
            passedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(0, 1, passedTime / duration);
            newColor = new Color(startingColor.r, startingColor.g, startingColor.b, currentAlpha);
            thisSprite.color = newColor;

            if(currentAlpha == 1)
            {
                fadeIN = false;
                passedTime = 0;
            }
        }

        if(fadeOUT)
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
