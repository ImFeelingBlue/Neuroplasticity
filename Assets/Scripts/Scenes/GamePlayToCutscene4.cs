using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayToCutscene4 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Pipe1SetupTrigger Pipe1SetupTrigger;
    public Pipe2SetupTrigger Pipe2SetupTrigger;
    public Pipe3SetupTrigger Pipe3SetupTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && Pipe1SetupTrigger.pipe1GotSetup && Pipe2SetupTrigger.pipe2GotSetup && Pipe3SetupTrigger.pipe3GotSetup)
        {
            SceneManager.LoadScene("CutScene 4");
        }
    }
}
