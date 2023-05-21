using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Collider2D detective;
    public Transform shootPoint;
    public Animator animDetective;
    private bool isShootingTrigger = false;
    private float delay;

    private void OnTriggerStay2D()
    {
        if (detective.CompareTag("ShootingZone"))
        {
            isShootingTrigger = false;
        }
    }

    private void OnTriggerExit2D()
    {
        if (detective.CompareTag("ShootingZone"))
        {
            isShootingTrigger = false;
        }
            
    }

    // Update is called once per frame
    private void Update()
    {

        Debug.Log(isShootingTrigger);
        if (isShootingTrigger)
        { 
            animDetective.SetBool("GunReady", true);
            if (delay <= 0f)
            {
                if (Input.GetMouseButton(0))
                {
                    animDetective.SetBool("Shoot", true);
                    Instantiate(bullet, shootPoint.position, transform.rotation);
                    delay = 2;
                }

            }
            else
            {
                animDetective.SetBool("Shoot", false);
                delay -= Time.deltaTime;
            }
        }
        else{
            animDetective.SetBool("GunReady", false);
        }
        

    }
}
