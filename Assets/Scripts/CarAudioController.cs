using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioController : MonoBehaviour
{
    public float defaultPitch = 0.9f;
    public float maxPitch = 2.2f;
    public float pitchChangeSpeed = 3f;
    public float turnPitchBoost = 0.2f;

    private AudioSource engineAudio;
    private float targetPitch;

    void Start()
    {
        engineAudio = GetComponent<AudioSource>();
        engineAudio.pitch = defaultPitch;
        targetPitch = defaultPitch;
    }

    void Update()
    {
        // Check for key inputs
        bool isAccelerating = Input.GetKey(KeyCode.UpArrow);
        bool isReversing = Input.GetKey(KeyCode.DownArrow);
        bool isTurning = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        // Decide target pitch based on input
        if (isAccelerating || isReversing)
        {
            targetPitch = maxPitch + (isTurning ? turnPitchBoost : 0f);
        }
        else
        {
            targetPitch = defaultPitch;
        }

        // Smoothly interpolate pitch toward target
        engineAudio.pitch = Mathf.Lerp(engineAudio.pitch, targetPitch, Time.deltaTime * pitchChangeSpeed);
    }
}
