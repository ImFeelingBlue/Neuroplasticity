using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MessagesSellection : MonoBehaviour
{
    [SerializeField] private GameObject message1;
    [SerializeField] private GameObject message2;
    [SerializeField] private GameObject message3;
    [SerializeField] private GameObject panelBack;

    // Array to hold the panels in a 1x4 grid
    private GameObject[] panelArray;

    // Current index
    private int currentIndex = 0;

    private void Start()
    {
        // Initialize the panelArray
        panelArray = new GameObject[] { message1, message2, message3, panelBack };

        // Activate the starting panel (message1)
        SetPanelActive(0);
    }

    private void Update()
    {
        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Move to the next panel
            currentIndex = (currentIndex + 1) % panelArray.Length;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            // Move to the previous panel
            currentIndex = (currentIndex - 1 + panelArray.Length) % panelArray.Length;
        }

        // Activate the current panel based on the index
        SetPanelActive(currentIndex);
    }

    // Function to activate a specific panel based on the index
    private void SetPanelActive(int index)
    {
        // Deactivate all panels
        foreach (var panel in panelArray)
        {
            panel.SetActive(false);
        }

        // Activate the specified panel
        panelArray[index].SetActive(true);
    }
}
