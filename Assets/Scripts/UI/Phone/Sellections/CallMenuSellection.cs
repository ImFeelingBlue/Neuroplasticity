using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenuSellection : MonoBehaviour
{
    [SerializeField] private GameObject callClick;
    [SerializeField] private GameObject numberText;
    [SerializeField] private GameObject panelBack;

    // Array to hold the panels in a 1x4 grid
    private GameObject[] panelArray;

    // Current index
    private int currentIndex = 0;

    private void Start()
    {
        // Initialize the panelArray
        panelArray = new GameObject[] { callClick, numberText, panelBack };

        // Activate the starting panel (callClick)
        SetPanelActive(0);
    }

    private void Update()
    {
        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            // Move to the next panel
            currentIndex = (currentIndex + 1) % panelArray.Length;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
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
