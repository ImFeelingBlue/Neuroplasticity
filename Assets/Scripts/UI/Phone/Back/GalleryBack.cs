using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryBack : MonoBehaviour
{
    [SerializeField] private GameObject galleryBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject galleryMenu;


    // Update is called once per frame
    void Update()
    {
        galleryToMainMenu();
    }

    void galleryToMainMenu()
    {
        if (mainMenu != null && galleryMenu != null && galleryBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            galleryMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
