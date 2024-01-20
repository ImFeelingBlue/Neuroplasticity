using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CutSceneOne : MonoBehaviour
{
    [SerializeField] private GameObject[] allGameObjects;

    private int currentIndex = 1; // Start enabling from the second object

    // Start is called before the first frame update
    void Start()
    {
        DisableAllExceptFirst();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableNextObject();
        }
    }

    private void DisableAllExceptFirst()
    {
        for (int i = 1; i < allGameObjects.Length; i++)
        {
            if (allGameObjects[i] != null)
            {
                allGameObjects[i].SetActive(false);
            }
            else
            {
                Debug.LogWarning("GameObject at index " + i + " is not assigned.");
            }
        }
    }

    private void EnableNextObject()
    {
        if (currentIndex < allGameObjects.Length)
        {
            if (allGameObjects[currentIndex] != null)
            {
                allGameObjects[currentIndex].SetActive(true);
                currentIndex++;
            }
            else
            {
                Debug.LogWarning("GameObject at index " + currentIndex + " is not assigned.");
            }
        }
        else
        {
            Debug.Log("All objects are already enabled.");
        }
    }
}
