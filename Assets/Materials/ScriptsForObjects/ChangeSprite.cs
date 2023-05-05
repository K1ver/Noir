using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteReanderer;

    [SerializeField] public Sprite[] spriteArray;

    private int currentSprite = 0;

    private void Awake() {
        spriteReanderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D col){
        SpriteChange();
    }

    void SpriteChange(){
        spriteReanderer.sprite = spriteArray[currentSprite];
        currentSprite++;
        if(currentSprite >= spriteArray.Length)
        {
            currentSprite = 0;
        }
    }
}
