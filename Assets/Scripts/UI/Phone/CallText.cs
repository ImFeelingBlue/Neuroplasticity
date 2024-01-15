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

    public CallMenuSellection callMenuSellection;

    // Update is called once per frame
    void Update()
    {
        // Pass valid characters to CheckForInputFieldFocus
        CheckForInputFieldFocus("0123456789#*");
    }

    private void CheckForInputFieldFocus(string validCharacters)
    {
        // Use lambda expression to set onValidateInput
        inputField.onValidateInput = (string text, int charIndex, char addedChar) => { return ValidateChar(validCharacters, addedChar); };

        if (callInputClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            // Focus on the InputField
            inputField.Select();
            inputField.ActivateInputField();
            callMenuSellection.canSwitchCall = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            callMenuSellection.canSwitchCall = true;
            inputField.text = "";
        }
    }

    private char ValidateChar(string validCharacters, char addedChar)
    {
        // Check if the added character is in the validCharacters string
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            // Valid character
            return addedChar;
        }
        else
        {
            // Invalid character
            return '\0';
        }
    }
}
