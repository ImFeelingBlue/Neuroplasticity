using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMenu : MonoBehaviour
{
    [SerializeField] GameObject EyeMenuPanel;

    private void Start()
    {
        EyeMenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (EyeMenuPanel != null && Input.GetKeyDown(KeyCode.Tab)) 
        {
            EyeMenuPanel.SetActive(false);
        }
    }
}
