using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowButton : MonoBehaviour
{

    public GameObject useItem;
    private bool isTrigger = false;

    private void OnTriggerStay2D(Collider2D col)
    {
        isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isTrigger = false;
    }

    private void Update()
    {
        if (isTrigger)
        {
            useItem.SetActive(true);
        }
        else 
        {
            useItem.SetActive(false);
        }

        
    }

}
