using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private string[] sentences;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "";
        dialogueBox.SetActive(false);
        UpdateDialogueText();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueBox.SetActive(true);
            NextSentence();
        }
    }

    private void NextSentence()
    {
        // Move to the next sentence
        currentIndex++;

        // Check if there are more sentences
        if (currentIndex < sentences.Length)
        {
            UpdateDialogueText();
        }
        else
        {
            Debug.Log("End of dialogue.");
        }
    }

    private void UpdateDialogueText()
    {
        // Update the text component with the current sentence
        if (dialogueText != null)
        {
            dialogueText.text = sentences[currentIndex];
        }
        else
        {
            Debug.LogError("Dialogue Text component is not assigned.");
        }
    }
}
