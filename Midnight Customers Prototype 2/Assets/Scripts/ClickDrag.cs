using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    bool isHeld = false;
    float startPosX;
    float startPosY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, -1);
        }
    }

    private void OnMouseDown()
    {
        //currently left or right mouse, can specify later if want
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y; //keeps mop from jumping around when picking it up

        isHeld = true;
    }

    private void OnMouseUp()
    {
        isHeld = false;
    }
}
