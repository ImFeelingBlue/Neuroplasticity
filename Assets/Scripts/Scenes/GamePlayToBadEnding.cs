using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayToBadEnding : MonoBehaviour
{
    [SerializeField] GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            SceneManager.LoadScene("last bad end");
        }
    }
}
