using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    public GameObject door;
    private bool onTrigger = false;
    private Animator anim;


    private States state
    {
        get { return (States)anim.GetInteger("AnimState"); }
        set { anim.SetInteger("AnimState", (int)value); }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        onTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (int)state == (int)States.close && onTrigger)
        {
            state = States.open;
            door.SetActive(false);
        }
            
        if (Input.GetKeyDown(KeyCode.E) && state == States.open && onTrigger)
        {
            state = States.close;
            door.SetActive(true);
        }

            
    }

    private enum States
    {
        open,
        close
    }
}
