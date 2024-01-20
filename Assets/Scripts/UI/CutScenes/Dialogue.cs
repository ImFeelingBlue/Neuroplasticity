using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private TMP_Text nameTagText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] sentences;
    private int currentIndex = 0;

    private int spaceCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDialogueText();
        dialogueBox.SetActive(false);
        nameTagText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
        }
        if (spaceCount == 3)
        {
            nameTagText.text = "Gabriel:";
        }
        else if (spaceCount == 4)
        {
            nameTagText.text = " ";
        }
        else if (spaceCount == 5) 
        {
            nameTagText.text = "Stranger 1:";
        }

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
