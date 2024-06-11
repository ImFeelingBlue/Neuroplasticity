using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject HospitalPaperPanel;
    [SerializeField] GameObject HospitalPaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        HospitalPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (HospitalPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            HospitalPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            HospitalPaperPanel.SetActive(true);
            Destroy(HospitalPaperPlaceHolderText);
        }
    }
}
