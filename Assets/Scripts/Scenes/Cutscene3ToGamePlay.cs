using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene3ToGamePlay : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private int spaceCount = 0;
    // Update is called once per frame
    void Update()
    {
        ChangeTheScene();
    }

    void ChangeTheScene()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
            if (spaceCount == 3)
            {
                // Change to the scene with the name "YourSceneName"
                SceneManager.LoadScene("TheGame");
            }
        }
    }
}
