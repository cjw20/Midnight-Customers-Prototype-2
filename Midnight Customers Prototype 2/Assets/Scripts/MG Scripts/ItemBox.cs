using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public bool boxOpen;
    public GameObject openedBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {

        if (!boxOpen)
        {
            OpenBox();
        }
        //open up box to pick item
    }


    void OpenBox()
    {
        boxOpen = true;
        openedBox.SetActive(true);
        //display items
    }

    void CloseBox()
    {
        boxOpen = false;
        openedBox.SetActive(false);
    }
}
