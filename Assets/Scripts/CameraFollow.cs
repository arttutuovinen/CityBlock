using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public Transform cameraTarget;
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset to maintain distance
    public float rotationSpeed = 100f; // Speed of rotation
    public float smoothTime = 0.1f; // Smoothness factor
    private float currentAngle = 0f;
    private float targetAngle = 0f;
    private float angleVelocity = 0f;

    void Update()
    {
        // Rotate left
        if (Input.GetKey(KeyCode.J))
        {
            targetAngle -= rotationSpeed * Time.deltaTime;
        }
        // Rotate right
        if (Input.GetKey(KeyCode.K))
        {
            targetAngle += rotationSpeed * Time.deltaTime;
        }
    }
    void LateUpdate()
    {
         // Smoothly interpolate between the current angle and the target angle
        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref angleVelocity, smoothTime);
        // Apply only the manual camera rotation, ignoring the player's rotation
        Quaternion cameraRotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 rotatedOffset = cameraRotation * offset;
        transform.position = player.position + rotatedOffset;
        transform.LookAt(cameraTarget.position);
        
    }
}
