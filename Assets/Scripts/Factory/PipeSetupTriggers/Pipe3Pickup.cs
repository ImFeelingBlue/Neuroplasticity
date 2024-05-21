using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe3Pickup : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public bool pipe3GotPickedTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            pipe3GotPickedTrigger = true;
        }
    }
}
