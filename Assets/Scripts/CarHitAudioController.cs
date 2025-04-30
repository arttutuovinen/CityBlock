using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitAudioController : MonoBehaviour
{
    public AudioClip crashClip;
    public float minCollisionForce = 0.1f; // Minimum force required to trigger sound
    public float volume = 1f;
    public float minPitch = 0.3f;
    public float maxPitch = 2.0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Only react to tagged objects
        if (collision.collider.CompareTag("Interactable"))
        {
            // Get collision force
            float impactForce = collision.relativeVelocity.magnitude;

            if (impactForce >= minCollisionForce && crashClip != null)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(crashClip, volume);
            }
        }
    }
}
