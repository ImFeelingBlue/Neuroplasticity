using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChurchAnimations : MonoBehaviour
{
    [SerializeField] private Animator animatorCross;
    [SerializeField] private Animator animatorLever;
    [SerializeField] private GameObject bloodSplashPanel;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject intactBody;

    [SerializeField] private GameObject Corpse1;
    [SerializeField] private GameObject Corpse2;
    [SerializeField] private GameObject Corpse3;
    [SerializeField] private GameObject Corpse4;
    [SerializeField] private GameObject Corpse5;
    [SerializeField] private GameObject Corpse6;
    [SerializeField] private GameObject Corpse7;
    [SerializeField] private GameObject Corpse8;
    [SerializeField] private GameObject Corpse9;
    [SerializeField] private GameObject Corpse10;
    [SerializeField] private GameObject Corpse11;

    private bool isPlayerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        if (intactBody != null)
        {
            intactBody.SetActive(true);

            Corpse1.SetActive(false);
            Corpse2.SetActive(false);
            Corpse3.SetActive(false);
            Corpse4.SetActive(false);
            Corpse5.SetActive(false);
            Corpse6.SetActive(false);
            Corpse7.SetActive(false);
            Corpse8.SetActive(false);
            Corpse9.SetActive(false);
            Corpse10.SetActive(false);
            Corpse11.SetActive(false);

            bloodSplashPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ActivateCross());
            animatorLever.SetBool("LeverPull", true);
            intactBody.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            isPlayerInTrigger = false;
        }
    }
    IEnumerator ClearBlood()
    {
        yield return new WaitForSeconds(7);
        bloodSplashPanel.SetActive(false);
    }

    IEnumerator ActivateCross()
    {
        yield return new WaitForSeconds(6);
        animatorCross.SetBool("LeverDown", true);
        StartCoroutine(BodyParts());
        StartCoroutine(ClearBlood());
    }
    IEnumerator BodyParts()
    {
        yield return new WaitForSeconds(1.3f);
        bloodSplashPanel.SetActive(true);
        Corpse1.SetActive(true);
        Corpse2.SetActive(true);
        Corpse3.SetActive(true);
        Corpse4.SetActive(true);
        Corpse5.SetActive(true);
        Corpse6.SetActive(true);
        Corpse7.SetActive(true);
        Corpse8.SetActive(true);
        Corpse9.SetActive(true);
        Corpse10.SetActive(true);
        Corpse11.SetActive(true);
    }
}
