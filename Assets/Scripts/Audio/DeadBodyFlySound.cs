using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyFlySound : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deadBodyFlySound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            audioSource.PlayOneShot(deadBodyFlySound);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            audioSource.Stop();
        }
    }
}
