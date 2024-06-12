using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewingKitSoundTrigger : MonoBehaviour
{
    public bool hasCollided = false; // This boolean will be set to true on collision
    [SerializeField] GameObject player; // Reference to the player GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            hasCollided = true;
        }
    }

    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(2f); // Wait until the next frame
        hasCollided = true;
    }
}
