using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesMenuBack : MonoBehaviour
{
    [SerializeField] private GameObject messagesMenuBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject messagesMenu;


    // Update is called once per frame
    void Update()
    {
        MessageToMainMenu();
    }

    void MessageToMainMenu()
    {
        if (mainMenu != null && messagesMenu != null && messagesMenuBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            messagesMenu.SetActive(false);
            mainMenu.SetActive(true);
        }        
    }
}
