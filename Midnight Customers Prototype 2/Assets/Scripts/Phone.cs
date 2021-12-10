using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public void ClosePhone()
    {
        this.gameObject.SetActive(false);
    }
}