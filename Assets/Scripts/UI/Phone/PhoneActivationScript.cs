using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhoneActivationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int phoneCount = 0;

    public bool dontOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && phoneCount == 0 && dontOpen == false)
        {
            animator.SetBool("isPhone", true);
            phoneCount = 1;
        }
        else if (Input.GetKeyDown(KeyCode.E) && phoneCount == 1 && dontOpen == false)
        {
            animator.SetBool("isPhone", false);
            phoneCount = 0;
        }
    }
}
