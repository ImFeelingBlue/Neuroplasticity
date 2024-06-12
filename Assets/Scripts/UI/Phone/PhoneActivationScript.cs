using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

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

    [SerializeField] private GameObject PhoneButtonsInformationPanel;
    [SerializeField] private TMP_Text PhoneButtonInformationPanelCounterText;
    private int phoneButtonInformationCounter = 10;
    private Coroutine panelCounterCoroutine;

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

    private void Start()
    {
        if (PhoneButtonsInformationPanel != null)
        {
            PhoneButtonsInformationPanel.SetActive(true);
        }
    }

    IEnumerator InformationPanelCounter()
    {
        while (phoneButtonInformationCounter > 0 && !dontOpen)
        {
            yield return new WaitForSeconds(1f);
            phoneButtonInformationCounter--;
            PhoneButtonInformationPanelCounterText.text = "Countdown: " + phoneButtonInformationCounter;
        }

        if (phoneButtonInformationCounter <= 0)
        {
            PhoneButtonsInformationPanel.SetActive(false);
            phoneCount = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPhoneAnimation();
    }

    private void SetPhoneAnimation()
    {
        if (Input.GetKeyDown(KeyCode.C) && phoneCount == 0 && !dontOpen)
        {
            animator.SetBool("isPhone", true);
            phoneCount = 1;
            if (panelCounterCoroutine != null)
            {
                StopCoroutine(panelCounterCoroutine);
            }
            panelCounterCoroutine = StartCoroutine(InformationPanelCounter());
        }
        else if (Input.GetKeyDown(KeyCode.C) && phoneCount == 1 && !dontOpen)
        {
            animator.SetBool("isPhone", false);
            phoneButtonInformationCounter = 10;
            phoneCount = 0;
            StartCoroutine(InformationPanelVisibility());
        }
    }

    IEnumerator InformationPanelVisibility()
    {
        yield return new WaitForSeconds(0.2f);
        PhoneButtonInformationPanelCounterText.text = "Countdown: 10";
        phoneButtonInformationCounter = 10;
        PhoneButtonsInformationPanel.SetActive(true);
    }
}
