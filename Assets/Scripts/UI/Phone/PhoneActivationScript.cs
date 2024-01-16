using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhoneActivationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bigPhone;
    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private GameObject messagesMenu;
    [SerializeField] private GameObject cameraMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject galleryMenu;


    private int phoneCount = 0;

    public bool dontOpen = false;

    private void Awake()
    {
        if (bigPhone != null && phone != null && mainMenu != null && callMenu != null && messagesMenu != null && cameraMenu != null && settingsMenu != null && mapMenu != null && galleryMenu != null)
        {
            bigPhone.SetActive(false);
            callMenu.SetActive(false);
            messagesMenu.SetActive(false);
            cameraMenu.SetActive(false);
            settingsMenu.SetActive(false);
            mapMenu.SetActive(false);
            galleryMenu.SetActive(false);

            phone.SetActive(true);
            mainMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPhoneAnimation();
    }

    private void SetPhoneAnimation()
    {
        if (Input.GetKeyDown(KeyCode.E) && phoneCount == 0 && dontOpen == false)
        {
            animator.SetBool("isPhone", true);
            phoneCount = 1;
        }
        else if (Input.GetKeyDown(KeyCode.E) && phoneCount == 1 && dontOpen == false)
        {
            animator.SetBool("isPhone", false);
            phoneCount = 0;
        }
    }
}
