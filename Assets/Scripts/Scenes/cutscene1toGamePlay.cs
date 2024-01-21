using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene1toGamePlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change to the scene with the name "YourSceneName"
            SceneManager.LoadScene("TheGame");
        }
    }
}
