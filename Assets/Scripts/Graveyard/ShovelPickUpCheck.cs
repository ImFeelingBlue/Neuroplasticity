using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelPickUpCheck : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public bool shovelPickedUp = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            shovelPickedUp = true;
        }
    }
}
