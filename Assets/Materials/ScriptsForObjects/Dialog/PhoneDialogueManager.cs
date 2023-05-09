using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDialogueManager : MonoBehaviour
{
    private int usedObj = 0;

    void Update()
    {
        usedObj = PlayerManager.UsedObjects;
        if (usedObj >= 4){
            this.GetComponent<DialogueTrigger>().enabled = true;
        }
    }
}
