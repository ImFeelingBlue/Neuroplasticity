using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSoundTrigger : MonoBehaviour
{
    public GameObject Player;
    public bool stairsSoundIsTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && Random.Range(0, 10) < 3)
        {
            stairsSoundIsTriggered = true;
        }
    }
}
