using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Detective>().transform
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
 