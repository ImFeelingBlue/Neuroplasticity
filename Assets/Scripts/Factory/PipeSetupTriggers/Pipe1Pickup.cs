using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1Pickup : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public bool pipe1GotPickedTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            pipe1GotPickedTrigger = true;
        }
    }
}
