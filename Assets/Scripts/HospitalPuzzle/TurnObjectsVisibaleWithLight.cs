using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectsVisibaleWithLight : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float raycastDistance = 15f;
    private const string VisibleWithTag = "VisableWithLight"; // Tag for the objects that should become visible
    private bool isHitting = false; // Flag to track if the raycast is hitting a valid object
    private float delayTimer = 3f; // Timer for delay before cubes disappear
    private float currentTimer = 0f; // Current timer value
    private bool timerReset = false; // Flag to track if the timer has been reset
    private FlashLight flashlight; // Reference to the FlashLight script

    private void Start()
    {
        // Get the FlashLight script component from the GameObject with the FlashLight script
        flashlight = FindObjectOfType<FlashLight>();
    }

    private void Update()
    {
        // Cast a ray from the light source in its forward direction
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, targetLayer))
        {
            // Check if the hit object has the desired tag
            if (hit.collider.CompareTag(VisibleWithTag))
            {
                isHitting = true;
                // If it does, enable the MeshRenderer component
                MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
                if (renderer != null && flashlight != null && flashlight.isOn)
                {
                    renderer.enabled = true;
                }
            }
        }
        else
        {
            // Reset timer if raycast is not hitting
            isHitting = false;
            if (!timerReset)
            {
                currentTimer = 0f;
                timerReset = true;
            }
        }

        // Delay logic
        if (!isHitting || (flashlight != null && !flashlight.isOn))
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= delayTimer)
            {
                // If the delay time has passed, disable the MeshRenderer of all objects with the tag
                GameObject[] visibleObjects = GameObject.FindGameObjectsWithTag(VisibleWithTag);
                foreach (GameObject obj in visibleObjects)
                {
                    MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                    if (renderer != null)
                    {
                        renderer.enabled = false;
                    }
                }
            }
        }
        else
        {
            // Reset the timer reset flag when the raycast hits an object again
            timerReset = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the raycast in the Scene view for visualization
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * raycastDistance);
    }
}
