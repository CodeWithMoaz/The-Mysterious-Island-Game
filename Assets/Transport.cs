using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform teleportPoint; // The point where the player will be teleported

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the teleport point
            other.transform.position = teleportPoint.position;
        }
    }
}
