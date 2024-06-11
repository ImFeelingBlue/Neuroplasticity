using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayToTheGoodEnding : MonoBehaviour
{
    [SerializeField] GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            SceneManager.LoadScene("last good end");
        }
    }
}
