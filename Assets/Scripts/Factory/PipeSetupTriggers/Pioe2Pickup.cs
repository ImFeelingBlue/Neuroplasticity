using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pioe2Pickup : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public bool pipe2GotPickedTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            pipe2GotPickedTrigger = true;
        }
    }
}
