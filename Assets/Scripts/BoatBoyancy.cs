using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBoyancy : MonoBehaviour
{
    public Transform waterPlane; // Reference to your water mesh
    public float scale = 1f; // Same as your noise Scale in Shader Graph
    public float wavePower = 1f; // Same as your WavePower in Shader Graph
    public Vector2 waterSpeed = new Vector2(0.1f, 0.1f); // Same as your WaterSpeed in Shader Graph

    void Update()
    {
        Vector3 boatPosition = transform.position;

        // Convert to object space of water
        Vector3 localPos = waterPlane.InverseTransformPoint(boatPosition);

        // UV is based on object-space XZ
        Vector2 uv = new Vector2(localPos.x, localPos.z);
        uv += waterSpeed * Time.time;

        // Simulate the noise used in shader
        float noiseValue = Mathf.PerlinNoise(uv.x * scale, uv.y * scale);

        // Apply wave power
        float waveHeight = Mathf.Pow(noiseValue, wavePower);

        // Final world Y position for the boat
        Vector3 newBoatPos = boatPosition;
        newBoatPos.y = waterPlane.position.y + waveHeight;
        
        // Smooth movement
        transform.position = Vector3.Lerp(transform.position, newBoatPos, Time.deltaTime * 2f);
    }
}
