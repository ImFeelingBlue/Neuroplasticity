using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SkillsPanel;
    [SerializeField] GameObject InformationPanel;
    bool pressCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        InformationPanel.SetActive(true);
        SkillsPanel.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        SkillsPanelVisability();
    }

    void SkillsPanelVisability()
    {
        if (Input.GetKeyDown(KeyCode.J) && !pressCheck)
        {
            SkillsPanel.SetActive(true);
            InformationPanel.SetActive(false);
            pressCheck = true;
        }
        else if (Input.GetKeyDown(KeyCode.J) && pressCheck)
        {
            SkillsPanel.SetActive(false);
            InformationPanel.SetActive(true);
            pressCheck = false;
        }
    }
}
