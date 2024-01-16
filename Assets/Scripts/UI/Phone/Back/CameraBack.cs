using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject bigPhone;
    [SerializeField] private GameObject cameraBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject cameraMenu;


    // Update is called once per frame
    void Update()
    {
        CameraToMainMenu();
    }

    void CameraToMainMenu()
    {
        if (bigPhone != null && mainMenu != null && cameraMenu != null && cameraBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            cameraMenu.SetActive(false);
            bigPhone.SetActive(false);
            phone.SetActive(true);
            mainMenu.SetActive(true);
            animator.SetBool("isPhone", true);
            Debug.Log("works");
        }
    }
}
