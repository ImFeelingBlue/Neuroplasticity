using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1SetupTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject pipe1;
    public Pipe1Pickup pipe1Pickup;
    public bool pipe1GotSetup = false;

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
        pipe1.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && pipe1Pickup.pipe1GotPickedTrigger)
        {
            pipe1.SetActive(true);
            pipe1GotSetup = true;
        }
    }
}
