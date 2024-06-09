using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallsTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public bool inTheEyeBallBox = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            inTheEyeBallBox = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            inTheEyeBallBox = false;
        }
    }
}
