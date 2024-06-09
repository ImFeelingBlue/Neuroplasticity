using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SymbolPhotoTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public bool playerBootEnabled = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerBootEnabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerBootEnabled = false;
        }
    }
}
