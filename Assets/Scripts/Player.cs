using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float acceleration = 10f; // Acceleration force
    public float steering = 2f; // Steering sensitivity
    public float maxSpeed = 20f; // Maximum speed
    public float minSpeedForTurning = 0.1f; // Minimum speed to allow turning

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Handle car movement and steering
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Acceleration input
        float moveInput = Input.GetAxis("Vertical");
        Vector3 forwardMovement = transform.forward * moveInput * acceleration * Time.deltaTime;

        // Apply forward movement
        rb.AddForce(forwardMovement, ForceMode.VelocityChange);

        // Steering input, but only allow turning if the car is moving
        if (rb.velocity.magnitude > minSpeedForTurning)
        {
            float turnInput = Input.GetAxis("Horizontal");
            float turnAmount = turnInput * steering * Time.deltaTime;

            // Rotate the car
            transform.Rotate(0, turnAmount, 0);
        }

        // Limit the car's speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
