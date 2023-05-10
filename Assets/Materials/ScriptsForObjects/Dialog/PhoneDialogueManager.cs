using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDialogueManager : MonoBehaviour
{
    private int usedObj = 0;
    [SerializeField] public AudioSource phoneSound;
    [SerializeField] public AudioSource callOn;

    private bool ComponentEnabled = false;
    private bool call = false;

    void Update()
    {
        usedObj = PlayerManager.UsedObjects;
        
        if (usedObj == 4 && !ComponentEnabled){
            phoneSound.Play();
            this.GetComponent<DialogueTrigger>().enabled = true;
            this.GetComponent<ChangeSprite>().enabled = true;
            this.GetComponent<ShowButton>().enabled = true;
            ComponentEnabled = true;
        }
        if(usedObj == 5 && !call)
        {
            phoneSound.Stop();
            callOn.Play();
            call = true;
        }
    }
}
