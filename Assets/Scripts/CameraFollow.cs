using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset to maintain distance

    void LateUpdate()
    {
        if (player != null)
        {
            // Keep the camera at the player's position with the given offset
            transform.position = player.position + offset;
        }
    }
}
