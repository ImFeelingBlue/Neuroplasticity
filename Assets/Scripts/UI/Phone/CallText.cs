using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class CallText : MonoBehaviour
{
    [SerializeField] private GameObject callButtonClicker;

    [SerializeField] private GameObject callInputClicker;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text displayText;

    [SerializeField] private GameObject CallBackClicker;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject CallMenu;

    public CallSellection callSellection;

    private bool isInputFieldFocused = false;
    private string enteredText = "";

    // Update is called once per frame
    void Update()
    {
        // Pass valid characters to CheckForInputFieldFocus
        CheckForInputFieldFocus("0123456789#*");
        CallToMainMenu();
    }

    private void CheckForInputFieldFocus(string validCharacters)
    {
        // Use lambda expression to set onValidateInput
        inputField.onValidateInput = (string text, int charIndex, char addedChar) => { return ValidateChar(validCharacters, addedChar); };

        if (callInputClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            ToggleInputFieldFocus();
        }
        else if (!callInputClicker.activeSelf)
        {
            // Unfocus input field and keep the text
            inputField.DeactivateInputField();
            callSellection.canSwitchCall = true;
            isInputFieldFocused = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            callSellection.canSwitchCall = true;
            inputField.text = "";
        }

        if (callButtonClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            inputField.text = "";

            Func<string, int> calling = enteredText =>
            {
                if (enteredText == "911")
                {
                    return 0;
                }
                else if (enteredText == "05326683571")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            };

            // Invoke the delegate with an argument
            int result = calling(enteredText);

            // Log the result to the console
            if (result == 0)
            {
                Debug.Log("Open the '911' calling screen");
            }
            else if (result == 1)
            {
                Debug.Log("Open the 'mother' calling screen");
            }
            else if (result == 2)
            {
                Debug.Log("Open 'this number does not exist' screen");
            }
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

    private void ToggleInputFieldFocus()
    {
        if (isInputFieldFocused)
        {
            // Unfocus input field and keep the text
            enteredText = inputField.text;
            inputField.DeactivateInputField();
            callSellection.canSwitchCall = true;
            isInputFieldFocused = false;
        }
        else
        {
            // Focus input field and set the stored text
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
            callSellection.canSwitchCall = false;
            isInputFieldFocused = true;
        }
    }
    void CallToMainMenu()
    {
        if (mainMenu != null && CallMenu != null && CallBackClicker.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            inputField.text = "";
            CallMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
