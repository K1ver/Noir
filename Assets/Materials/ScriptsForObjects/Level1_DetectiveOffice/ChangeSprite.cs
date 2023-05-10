using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteReanderer;

    [SerializeField] public Sprite[] spriteArray;

    private bool isTrigger = false;

    private bool isColor = false;

    private int currentSprite = 0;

    private void Awake() {
        spriteReanderer = gameObject.GetComponentInChildren<SpriteRenderer>();
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
        if (isTrigger && !isColor)
        {
            IsColor();
        }
        if(!isTrigger && isColor)
        {
            NotIsColor();
        }
    }

    void IsColor()
    {
        isColor = true;
        currentSprite = 1;
        spriteReanderer.sprite = spriteArray[currentSprite];
        
    }

    void NotIsColor()
    {
        isColor = false;
        currentSprite = 0;
        spriteReanderer.sprite = spriteArray[currentSprite];
    }

    /*void SpriteChange(){
        spriteReanderer.sprite = spriteArray[currentSprite];
        currentSprite++;
        if(currentSprite >= spriteArray.Length)
        {
            currentSprite = 0;
        }
    }*/
}
