using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnTheValumeOff : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text audioStatusText;

    private bool isMuted = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ToggleAudio();
            UpdateAudioStatusText();
        }
    }

    void ToggleAudio()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0.0f : 1.0f; // Toggle the audio

    }

    void UpdateAudioStatusText()
    {
        if (audioStatusText != null)
        {
            audioStatusText.text = isMuted ? "The volume is: off" : "The volume is: on";
        }
    }
}
