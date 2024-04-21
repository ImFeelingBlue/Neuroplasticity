using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light lightSource;
    public bool isOn = false;
    private float flickerDuration; // Duration for flicker
    private float flickerTimer = 1f; // Timer for flicker
    private bool lightBool = true;

    private void Start()
    {
        // Ensure that the lightSource is initially off
        lightSource.intensity = 3f;
        lightSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle the flashlight on/off when the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            Invoke("ToggleLight", 0.3f);
        }

        flickerTimer -= Time.deltaTime;

        if (flickerTimer <= 0)
        {
            flickerDuration = Random.Range(0f, 2f);
            if (isOn)
            {
                // Randomly change intensity during flicker duration
                if (lightBool)
                {
                    lightSource.intensity = Random.Range(0.5f, 1f);
                }
                flickerDuration -= Time.deltaTime;
                if (flickerDuration <= 0)
                {
                    lightSource.intensity = 3f;
                    lightBool = false;
                    Invoke("FlashLightTimerSetter", 2.5f);
                }
            }
        }
    }

    void FlashLightTimerSetter()
    {
        flickerTimer = Random.Range(0f, 5f);
        lightBool = true;
    }

    void ToggleLight()
    {
        // Toggle the visibility of the lightSource
        isOn = !isOn;
        lightSource.enabled = isOn;

        // Reset intensity when turning the light off
        if (!isOn)
        {
            lightSource.intensity = 1f;
        }
    }
}
