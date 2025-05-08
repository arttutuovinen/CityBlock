using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Only trigger the effect if the other object is tagged "Interactable"
        if (collision.collider.CompareTag("Interactable"))
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Quaternion rot = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(hitEffectPrefab, contactPoint, rot);
        }
    }
}
