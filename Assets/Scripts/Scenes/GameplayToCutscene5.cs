using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayToCutscene5 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            SceneManager.LoadScene("mushroom");
        }
    }
}
