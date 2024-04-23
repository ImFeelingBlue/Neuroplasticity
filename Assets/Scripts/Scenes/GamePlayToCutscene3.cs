using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayToCutscene3 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Change to the scene with the name "YourSceneName"
            SceneManager.LoadScene("CutScene (3)");
        }
    }
}
