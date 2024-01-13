using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhoneActivationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private GameObject messagesMenu;
    [SerializeField] private GameObject cameraMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mapMenu;
    [SerializeField] private GameObject galleryMenu;


    private int phoneCount = 0;

    public bool dontOpen = false;

    private void Start()
    {
        if (callMenu != null && messagesMenu != null && cameraMenu != null && settingsMenu != null && mapMenu != null && galleryMenu != null)
        {
            callMenu.SetActive(false);
            messagesMenu.SetActive(false);
            cameraMenu.SetActive(false);
            settingsMenu.SetActive(false);
            mapMenu.SetActive(false);
            galleryMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
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
