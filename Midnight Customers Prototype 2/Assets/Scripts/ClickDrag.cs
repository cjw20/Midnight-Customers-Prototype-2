using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    bool isHeld = false;
    float startPosX;
    float startPosY;
    float startPosZ;
    SpriteRenderer sprite;
    void Start()
    {
        startPosZ = this.gameObject.transform.localPosition.z;
        if(gameObject.TryGetComponent(out SpriteRenderer reference)){
            sprite = reference; 
        }

    }

    void Update()
    {
        if (isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, startPosZ);
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
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }

    private void OnMouseUp()
    {
        isHeld = false;
    }

    void OnMouseOver(){
        if (!isHeld) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
    }

    void OnMouseExit(){
        if (!isHeld) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }
}