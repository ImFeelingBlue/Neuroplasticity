using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBack : MonoBehaviour
{
    [SerializeField] private GameObject mapBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mapMenu;


    // Update is called once per frame
    void Update()
    {
        MessageToMainMenu();
    }

    void MessageToMainMenu()
    {
        if (mainMenu != null && mapMenu != null && mapBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            mapMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
