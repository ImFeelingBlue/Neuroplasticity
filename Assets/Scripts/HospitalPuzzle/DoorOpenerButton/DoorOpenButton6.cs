using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenButton6 : MonoBehaviour
{
    // Reference to the materials you want to use
    [SerializeField] Material greenMaterial;
    [SerializeField] Material whiteMaterial;
    public bool correctColor6 = false;

    // Flag to track the current state of the cube
    private bool isGreen = false;

    private Renderer rend;

    private void Start()
    {
        // Get the Renderer component
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        // Toggle the flag
        isGreen = !isGreen;

        // Change the material based on the flag
        if (isGreen)
        {
            // Change to green material
            if (greenMaterial != null)
            {
                rend.material = greenMaterial;
                correctColor6 = true;
            }
            else
            {
                Debug.LogWarning("Green material is not assigned!");
            }
        }
        else
        {
            // Change to white material
            if (whiteMaterial != null)
            {
                rend.material = whiteMaterial;
                correctColor6 = false;
            }
            else
            {
                Debug.LogWarning("White material is not assigned!");
            }
        }
    }
}
