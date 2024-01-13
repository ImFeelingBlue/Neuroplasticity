using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenuBack : MonoBehaviour
{
    [SerializeField] private GameObject CallBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject CallMenu;


    // Update is called once per frame
    void Update()
    {
        CallToMainMenu();
    }

    void CallToMainMenu()
    {
        if (mainMenu != null && CallMenu != null && CallBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            CallMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
