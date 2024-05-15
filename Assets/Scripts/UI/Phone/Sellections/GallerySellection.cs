using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallerySellection : MonoBehaviour
{
    [SerializeField] private GameObject panelGalleryImages;
    [SerializeField] private GameObject panelGalleryImages1;
    [SerializeField] private GameObject panelGalleryImages2;
    [SerializeField] private GameObject panelGalleryImages3;
    [SerializeField] private GameObject panelGalleryImages4;
    [SerializeField] private GameObject panelGalleryImages5;
    [SerializeField] private GameObject panelGalleryImages6;
    [SerializeField] private GameObject panelGalleryImages7;
    [SerializeField] private GameObject panelGalleryImages8;
    [SerializeField] private GameObject panelSelection;
    [SerializeField] private GameObject panelBackClicker;

    // Array to hold the panels in a 4x3 grid
    private GameObject[,] panelGrid;

    // Current row and column indices
    private int currentRow = 0;
    private int currentCol = 0;

    private void Start()
    {
        // Initialize the panelGrid array
        panelGrid = new GameObject[,]
        {
        { panelGalleryImages, panelGalleryImages1, panelGalleryImages2 },
        { panelGalleryImages5, panelGalleryImages4, panelGalleryImages3 },
        { panelGalleryImages6, panelGalleryImages7, panelGalleryImages8 },
        { panelSelection, null, panelBackClicker }
        };

        // Activate the starting panel (Gallery Images panel)
        SetPanelActive(currentRow, currentCol);
    }

    private void Update()
    {
        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Move to the next column
            currentCol = (currentCol + 1) % panelGrid.GetLength(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move to the previous column
            currentCol = (currentCol - 1 + panelGrid.GetLength(1)) % panelGrid.GetLength(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Move to the next row
            currentRow = (currentRow + 1) % panelGrid.GetLength(0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Move to the previous row
            currentRow = (currentRow - 1 + panelGrid.GetLength(0)) % panelGrid.GetLength(0);
        }

        // Activate the current panel based on row and column indices
        SetPanelActive(currentRow, currentCol);
    }

    // Function to activate a specific panel based on row and column indices
    private void SetPanelActive(int row, int col)
    {
        // Deactivate all panels
        foreach (var panel in panelGrid)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }

        // Activate the current panel
        if (panelGrid[row, col] != null)
        {
            panelGrid[row, col].SetActive(true);
        }
    }
}
