using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenScreens : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private GameObject callCliker;
    [SerializeField] private GameObject messagesMenu;
    [SerializeField] private GameObject messagesClicker;
    [SerializeField] private GameObject cameraMenu;
    [SerializeField] private GameObject cameraClicker;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject settingsClicker;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject mapClicker;
    [SerializeField] private GameObject galleryMenu;
    [SerializeField] private GameObject galleryClicker;

    public void Update()
    {
        CheckMenuStatus(callMenu, callCliker);
        CheckMenuStatus(messagesMenu, messagesClicker);
        CheckMenuStatus(cameraMenu, cameraClicker);
        CheckMenuStatus(settingsMenu, settingsClicker);
        CheckMenuStatus(mapMenu, mapClicker);
        CheckMenuStatus(galleryMenu, galleryClicker);
    }

    private void CheckMenuStatus(GameObject menu, GameObject clicker)
    {
        if (mainMenu != null && menu != null && clicker != null && clicker.activeSelf && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            mainMenu.SetActive(false);
            menu.SetActive(true);
        }
    }
}
