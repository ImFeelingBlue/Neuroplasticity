using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhoneDeactivationScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CanvasGroup CallBigPhoneCanvasGroup;
    [SerializeField] private Animator animator;

    public PhoneActivationScript phoneActivationScript;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SetBigPhoneVisibility(false);
            animator.SetBool("isPhone", true);
            phoneActivationScript.dontOpen = false;
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
