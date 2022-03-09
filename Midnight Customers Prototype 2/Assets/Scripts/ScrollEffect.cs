using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollEffect : MonoBehaviour
{
    public bool scrolling;
    public RectTransform rect;
    public float scrollRate;
    // Start is called before the first frame update
    void Start()
    {
        scrolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (scrolling)
        {
            rect.anchoredPosition += new Vector2(0, scrollRate * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
