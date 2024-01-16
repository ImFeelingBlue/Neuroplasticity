using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsBack : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject settingsBackClicker;

    [SerializeField] private GameObject bigPhone;
    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        settingsBackClicker.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            bigPhone.SetActive(false);
            settingsMenu.SetActive(false);
            phone.SetActive(true);
            mainMenu.SetActive(true);
            animator.SetBool("isPhone", true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // When the cursor enters
    public void OnPointerEnter(PointerEventData eventData)
    {
        settingsBackClicker.SetActive(true);
    }

    // When the cursor exits
    public void OnPointerExit(PointerEventData eventData)
    {
        settingsBackClicker.SetActive(false);
    }
}
