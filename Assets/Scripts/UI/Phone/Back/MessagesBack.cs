using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesBack : MonoBehaviour
{
    [SerializeField] private GameObject messagesBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject messagesMenu;


    // Update is called once per frame
    void Update()
    {
        MessageToMainMenu();
    }

    void MessageToMainMenu()
    {
        if (mainMenu != null && messagesMenu != null && messagesBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            messagesMenu.SetActive(false);
            mainMenu.SetActive(true);
        }        
    }
}
