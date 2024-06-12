using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalWriting : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip textSound;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject HospitalWritingOnTheWall;
    private bool lockIt = false;

    private void Start()
    {
        HospitalWritingOnTheWall.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            HospitalWritingOnTheWall.SetActive(true);
            audioSource.PlayOneShot(textSound);
            lockIt = true;
        }
    }
}
