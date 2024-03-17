using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class CutScene1 : MonoBehaviour
{
    [SerializeField] private GameObject[] allScenes;
    [SerializeField] int[] playTheScenes = new int[0] { };

    int spaceCount = 0;
    bool contains = false;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        for (int i = 0; i < allScenes.Length; i++)
        {
            if (allScenes[i] != null)
            {
                allScenes[i].SetActive(false);
            }
            else
            {
                Debug.LogWarning("GameObject at index " + i + " is not assigned.");
            }
        }
    }

    private void EnableNextObject()
    {
        if (currentIndex < allScenes.Length)
        {
            if (allScenes[currentIndex] != null)
            {
                allScenes[currentIndex].SetActive(true);
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
