using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneToQuit : MonoBehaviour
{
    private int spaceCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCounter++;
            if (spaceCounter == 3)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}
