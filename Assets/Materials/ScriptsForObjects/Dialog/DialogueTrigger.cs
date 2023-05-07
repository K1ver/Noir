using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private bool isTrigger = false;
    private bool dialogueStart = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
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
        if (Input.GetKeyDown(KeyCode.E) && isTrigger && !dialogueStart)
        {
            dialogueStart = true;
            TriggerDialogue();
        }
    }
}
