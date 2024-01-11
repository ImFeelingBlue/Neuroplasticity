using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CallActivation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator animator;
    [SerializeField] private CanvasGroup CallBigPhoneCanvasGroup;

    public PhoneActivationScript phoneActivationScript;

    private void Start()
    {
        SetBigPhoneVisibility(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SetBigPhoneVisibility(true);
            phoneActivationScript.dontOpen = true;
            animator.SetBool("isPhone", false);
        }
    }

    private void SetBigPhoneVisibility(bool isVisible)
    {
        // Set the alpha based on the desired visibility
        CallBigPhoneCanvasGroup.alpha = isVisible ? 1 : 0;

        // Optionally, you can also disable interaction when the panel is transparent
        CallBigPhoneCanvasGroup.interactable = isVisible;

        // Optionally, you can also disable raycasting when the panel is transparent
        CallBigPhoneCanvasGroup.blocksRaycasts = isVisible;
    }
}
