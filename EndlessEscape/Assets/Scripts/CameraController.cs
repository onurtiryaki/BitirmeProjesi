using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }


    void Start()
    {
        offset = transform.position-player.position;
    }

    
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
