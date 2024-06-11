using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastCutscenestoCredits : MonoBehaviour
{
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
            if (spaceCount == 2)
            {
                // Change to the scene with the name "YourSceneName"
                SceneManager.LoadScene("endcredits");
            }
        }
    }
}
