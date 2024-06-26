using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSellection : MonoBehaviour
{
    [SerializeField] private GameObject panelCall;
    [SerializeField] private GameObject panelMessages;
    [SerializeField] private GameObject panelCamera;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelMap;
    [SerializeField] private GameObject panelGallery;

    [SerializeField] private AudioSource audioSourceManinMenuSwitch;
    [SerializeField] private AudioClip switchSound; 

    // Array to hold the panels in a 3x2 grid
    private GameObject[,] panelGrid;

    // Current row and column indices
    private int currentRow = 0;
    private int currentCol = 0;

    private void Start()
    {
        // Initialize the panelGrid array
        panelGrid = new GameObject[,]
        {
            { panelCall, panelMessages, panelCamera },
            { panelSettings, panelMap, panelGallery }
        };

        // Activate the starting panel (Call panel)
        SetPanelActive(currentRow, currentCol);
    }

    private void Update()
    {
        bool panelSwitched = false;

        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Move to the next column
            currentCol = (currentCol + 1) % panelGrid.GetLength(1);
            panelSwitched = true;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move to the previous column
            currentCol = (currentCol - 1 + panelGrid.GetLength(1)) % panelGrid.GetLength(1);
            panelSwitched = true;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Move to the next row
            currentRow = (currentRow + 1) % panelGrid.GetLength(0);
            panelSwitched = true;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Move to the previous row
            currentRow = (currentRow - 1 + panelGrid.GetLength(0)) % panelGrid.GetLength(0);
            panelSwitched = true;
        }

        if (panelSwitched)
        {
            // Activate the current panel based on row and column indices
            SetPanelActive(currentRow, currentCol);
            PlaySwitchSound(); // Play the sound
        }
    }

    // Function to activate a specific panel based on row and column indices
    private void SetPanelActive(int row, int col)
    {
        // Deactivate all panels
        foreach (var panel in panelGrid)
        {
            panel.SetActive(false);
        }

        // Activate the current panel
        panelGrid[row, col].SetActive(true);
    }

    private void PlaySwitchSound()
    {
        if (audioSourceManinMenuSwitch != null && switchSound != null)
        {
            audioSourceManinMenuSwitch.PlayOneShot(switchSound);
        }
    }
}
