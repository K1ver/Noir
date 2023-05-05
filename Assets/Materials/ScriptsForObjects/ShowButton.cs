using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowButton : MonoBehaviour
{

    // Update is called once per frame
    public GameObject useItem;


    private void OnTriggerStay2D(Collider2D col)
    {
        useItem.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        useItem.SetActive(false);
    }

}
