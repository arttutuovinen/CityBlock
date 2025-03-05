using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Quaternion initialRotation; // Stores the initial rotation of the camera

    void Start()
    {
        // Save the camera's initial rotation
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Keep the camera's rotation unchanged
        transform.rotation = initialRotation;
    }
}
