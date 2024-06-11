using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject OfferPaperPanel;
    [SerializeField] GameObject OfferPaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        OfferPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (OfferPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            OfferPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            OfferPaperPanel.SetActive(true);
            Destroy(OfferPaperPlaceHolderText);
        }
    }
}
