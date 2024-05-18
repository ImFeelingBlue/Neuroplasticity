using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSourceBuzz;
    [SerializeField] private AudioSource AudioSourceClick;
    [SerializeField] private AudioClip lightBuzz;
    [SerializeField] private AudioClip lightOpenClick;
    private bool lightBuzzingCheck = false;
    private bool lightOpenClickCheck = false;

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
        if (isOn)
        {
            if (!lightOpenClickCheck)
            {
                AudioSourceClick.PlayOneShot(lightOpenClick);
                lightOpenClickCheck = true;
            }
        }
        else if (!isOn)
        {
            lightOpenClickCheck = false;
        }

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
                    lightSource.intensity = Random.Range(0.5f, 1.5f);
                    if (!lightBuzzingCheck)
                    {
                        AudioSourceBuzz.PlayOneShot(lightBuzz);
                        lightBuzzingCheck = true;
                    }
                }
                flickerDuration -= Time.deltaTime;
                if (flickerDuration <= 0)
                {
                    lightSource.intensity = 3f;
                    lightBuzzingCheck = false;
                    lightBool = false;
                    AudioSourceBuzz.Stop();
                    Invoke("FlashLightTimerSetter", 2.5f);
                }
            }
        }
    }

    void FlashLightTimerSetter()
    {
        flickerTimer = Random.Range(0f, 2f);
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
            lightSource.intensity = 3f;
        }
    }
}
