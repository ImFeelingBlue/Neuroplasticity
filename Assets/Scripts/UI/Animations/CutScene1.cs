using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class CutScene1 : MonoBehaviour
{
    [SerializeField] private GameObject[] allGameObjects;
    [SerializeField] int[] playTheScenes = new int[0] { };

    int spaceCount = 0;
    bool contains = false;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DisableAllGameObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
            contains = playTheScenes.Contains(spaceCount);
        }
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && contains)
        {
            EnableNextObject();
        }
    }

    private void DisableAllGameObjects()
    {
        for (int i = 0; i < allGameObjects.Length; i++)
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
