using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CallText : MonoBehaviour
{
    [SerializeField] private GameObject callInputClicker;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text displayText;

    // Update is called once per frame
    void Update()
    {
        CheckForInputFieldFocus();
    }
    public void CheckForInputFieldFocus()
    {
        if (callInputClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            // Focus on the InputField
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}
