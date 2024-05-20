using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe3SetupTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject pipe3;
    public Pipe3Pickup pipe3Pickup;
    public bool pipe3GotSetup = false;

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
        pipe3.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && pipe3Pickup.pipe3GotPickedTrigger)
        {
            pipe3.SetActive(true);
            pipe3GotSetup = true;
        }
    }
}
