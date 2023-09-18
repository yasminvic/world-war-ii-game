using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public float delay;

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, playerPosition.position, 0.5f);
    }
}
