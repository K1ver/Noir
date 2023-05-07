using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFlicker : MonoBehaviour
{
    [SerializeField] public GameObject light;

    private int time;

    private void Start() {

        StartCoroutine(Flick());
    }
    
    private IEnumerator Flick(){
        time = Random.Range(5, 15);

        yield return new WaitForSeconds(time);

        light.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        light.SetActive(true);

        yield return new WaitForSeconds(0.05f);

        light.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        light.SetActive(true);

        StartCoroutine(Flick());
    }
}
