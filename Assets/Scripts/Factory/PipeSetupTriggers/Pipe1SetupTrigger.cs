using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1SetupTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject pipe1;

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
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            pipe1.SetActive(true);
        }
    }
}
