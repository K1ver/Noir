using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private bool isTrigger = false;
    private bool dialogueStart = false;
    private BoxCollider2D coll;
    
    public bool IsTrigger{
        get {return isTrigger;}
        set {isTrigger = value;}
    }

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        IsTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        IsTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTrigger && !dialogueStart)
        {
            PlayerManager.UsedObjects = 1;
            Debug.Log(PlayerManager.UsedObjects);
            TriggerDialogue();
            dialogueStart = true;
            coll.enabled = false;
        }
    }
}
