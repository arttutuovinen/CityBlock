using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : MonoBehaviour
{
    public Transform waterPlane; // The water mesh
    public float scale = 1f;
    public float wavePower = 1f;
    public Vector2 waterSpeed = new Vector2(0.1f, 0.1f);
    
    void Update()
    {
        Vector3 boatPosition = transform.position;

        // Get world to object space for the water mesh
        Vector3 localPos = waterPlane.InverseTransformPoint(boatPosition);

        // UV in object space
        Vector2 uv = new Vector2(localPos.x, localPos.z);
        uv += waterSpeed * Time.time;

        // Sample noise
        float noiseValue = Mathf.PerlinNoise(uv.x * scale, uv.y * scale);

        // Apply wave power (power function)
        float waveHeight = Mathf.Pow(noiseValue, wavePower);

        // Get final world position of wave height
        Vector3 newBoatPos = boatPosition;
        newBoatPos.y = waterPlane.position.y + waveHeight;
    }
}
