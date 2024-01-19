using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwitchBetweenScreens : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject phone;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private GameObject callCliker;
    [SerializeField] private GameObject messagesMenu;
    [SerializeField] private GameObject messagesClicker;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject settingsClicker;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject mapClicker;
    [SerializeField] private GameObject galleryMenu;
    [SerializeField] private GameObject galleryClicker;

    [SerializeField] private GameObject bigPhone;
    [SerializeField] private GameObject cameraMenu;
    [SerializeField] private GameObject cameraClicker;

    public void Update()
    {
        CheckMenuStatus(callMenu, callCliker);
        CheckMenuStatus(messagesMenu, messagesClicker);
        CheckMenuStatus(mapMenu, mapClicker);
        CheckMenuStatus(galleryMenu, galleryClicker);

        CheckBigMenuStatus(cameraMenu, cameraClicker);
        CheckBigMenuStatus(settingsMenu, settingsClicker);
    }

    private void CheckMenuStatus(GameObject menu, GameObject clicker)
    {
        if (mainMenu != null && menu != null && clicker != null && clicker.activeSelf && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            mainMenu.SetActive(false);
            menu.SetActive(true);
        }
    }

    private void CheckBigMenuStatus(GameObject bigMenu, GameObject bigCliker)
    {
        if (bigPhone != null && bigMenu != null && bigCliker != null && bigCliker.activeSelf && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            animator.SetBool("isPhone", false);
            bigPhone.SetActive(true);
            bigMenu.SetActive(true);
            phone.SetActive(false);

            if (bigMenu == settingsMenu)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; 
            }
        }
    }
}
