using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ChurchPaperPanel;
    [SerializeField] GameObject ChurchPaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        ChurchPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (ChurchPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            ChurchPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            ChurchPaperPanel.SetActive(true);
            Destroy(ChurchPaperPlaceHolderText);
        }
    }
}
