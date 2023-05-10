using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueCatScene : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isTrigger = false;
    private bool dialogueStart = false;
    private BoxCollider2D coll;

    public bool IsTrigger
    {
        get { return isTrigger; }
        set { isTrigger = value; }
    }

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerForCutScene>().StartDialogue(dialogue);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Trigger touched");
        IsTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        IsTrigger = false;
    }

    private void Update()
    {
        if (isTrigger && !dialogueStart)
        {
            TriggerDialogue();
            dialogueStart = true;
            coll.enabled = false;
        }
    }
}
