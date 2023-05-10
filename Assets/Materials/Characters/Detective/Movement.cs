using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private AudioSource run;
    [SerializeField] private AudioSource runStop;
    [SerializeField] private float speed = 10f;
    private bool isGrounded = false;
    private bool isDialogue = false;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private States state
    {
        get { return (States)anim.GetInteger("AnimState"); }
        set { anim.SetInteger("AnimState", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        run = GetComponent<AudioSource>();
    }

    private void Run()
    {
        if (isGrounded)
        {
            state = States.runStart;
        }

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Update()
    {

        isDialogue = DialogueManager.IsDialogue;

        Falling();
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.35f)
        {
            if (!run.isPlaying) run.Play();
        }
        else
        {
            run.Stop();
        }
        if (isGrounded) state = States.idle;


        if (Input.GetButton("Horizontal") && !isDialogue)
            Run();
    }

    private void Falling()
    {
        if (!isGrounded) anim.SetBool("Falling", true);
        
        else anim.SetBool("Falling", false);

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private enum States
    {
        idle,
        runStart
    }

}

