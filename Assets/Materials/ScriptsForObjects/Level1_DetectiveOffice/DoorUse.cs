using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    [SerializeField] public GameObject door;
    [SerializeField] public Animator animDoor;
    [SerializeField] public Animator animDetective;
    [SerializeField] public AudioSource soundDoorOpening;
    [SerializeField] public AudioSource soundDoorClosing;
    private bool isTrigger = false;
    private bool doorOpened = false;
    private bool lockationEnded = false;

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
        if (PlayerManager.UsedObjects >= 5)
        {
            lockationEnded = true;
            this.GetComponent<ShowButton>().enabled = true;
        }
            

        if (Input.GetKeyDown(KeyCode.E) && isTrigger && lockationEnded)
        {
            animDetective.SetInteger("AnimState", 2);
            
            if (doorOpened == true)
            {
                DoorClosing();
            } else
            {
                DoorOpening();
            }
        }
        
    }

    private void DoorOpening()
    {
        doorOpened = true;
        door.GetComponent<Collider2D>().enabled = false;
        animDoor.SetBool("DoorOpened", true);
        soundDoorOpening.Play();
    }

    private void DoorClosing()
    {
        doorOpened = false;
        door.GetComponent<Collider2D>().enabled = true;
        animDoor.SetBool("DoorOpened", false);
        soundDoorClosing.Play();
    }

}
