using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene1toGamePlay : MonoBehaviour
{
    private int spaceCount = 0;
    // Update is called once per frame
    void Update()
    {
        ChangeCutsceneOneToGamePlay();
    }

    void ChangeCutsceneOneToGamePlay()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
            if (spaceCount == 6)
            {
                // Change to the scene with the name "YourSceneName"
                SceneManager.LoadScene("TheGame");
            }
        }
    }
}
