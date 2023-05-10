using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Animator boxAnim;
    public Animator iconAnim;
    public Animator detectiveAnim;

    public GameObject detective;

    public Image ImgObj;
    private int currentSprite = 0;
    private Sprite[] spriteImage;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        detective.GetComponent<Movement>().enabled = false;
        detective.GetComponent<AudioSource>().enabled = false;
        detectiveAnim.SetInteger("AnimState", 0);
        

        boxAnim.SetBool("BoxOpen", true);
        iconAnim.SetBool("IconOpen", true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        spriteImage = dialogue.spriteArray;


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        if(spriteImage.Length == 1)
        {
            ImgObj.sprite = spriteImage[currentSprite];
        }
        else
        {
            ImgObj.sprite = spriteImage[currentSprite];
            currentSprite++;
        }
        
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void EndDialogue()
    {
        boxAnim.SetBool("BoxOpen", false);
        iconAnim.SetBool("IconOpen", false);
        detective.GetComponent<Movement>().enabled = true;
        detective.GetComponent<AudioSource>().enabled = true;
        currentSprite = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisplayNextSentence();
        }
    }
}
