using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrowCutSceneChoice : MonoBehaviour
{
    public ShovelPickUpCheck ShovelPickUpCheck;
    public GraveYardRaycast GraveYardRaycast;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject panelWithOnlyShovel;
    [SerializeField] GameObject panelWithOnlyEyeBalls;
    [SerializeField] GameObject panelWithBothShovelAndEyeBalls;

    // Start is called before the first frame update
    void Start()
    {
        panelWithBothShovelAndEyeBalls.SetActive(false);
        panelWithOnlyEyeBalls.SetActive(false);
        panelWithOnlyShovel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && ShovelPickUpCheck.shovelPickedUp && GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelWithBothShovelAndEyeBalls.SetActive(true);
        }
        else if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && !ShovelPickUpCheck.shovelPickedUp && GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelWithOnlyEyeBalls.SetActive(true);
        }
        else if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && ShovelPickUpCheck.shovelPickedUp && !GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelWithOnlyShovel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && ShovelPickUpCheck.shovelPickedUp && GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            panelWithBothShovelAndEyeBalls.SetActive(false);
        }
        else if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && !ShovelPickUpCheck.shovelPickedUp && GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            panelWithOnlyEyeBalls.SetActive(false);
        }
        else if (other.gameObject == Player && GraveYardRaycast != null && ShovelPickUpCheck != null && ShovelPickUpCheck.shovelPickedUp && !GraveYardRaycast.eyeBallsAreActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            panelWithOnlyShovel.SetActive(false);
        }
    }
}
