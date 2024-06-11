using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPaperTrigger : MonoBehaviour
{
   [SerializeField] GameObject Player;
    [SerializeField] GameObject FactoryPaperPanel;
    [SerializeField] GameObject FactoryPaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        FactoryPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (FactoryPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            FactoryPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            FactoryPaperPanel.SetActive(true);
            Destroy(FactoryPaperPlaceHolderText);
        }
    }
}
