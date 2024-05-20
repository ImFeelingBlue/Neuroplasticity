using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Pipe2SetupTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject pipe2;
    public Pioe2Pickup Pipe2Pickup;
    public bool pipe2GotSetup = false;

    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerInTrigger = false;
        }
    }

    private void Start()
    {
        pipe2.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && Pipe2Pickup.pipe2GotPickedTrigger)
        {
            pipe2.SetActive(true);
            pipe2GotSetup = true;
        }
    }
}
