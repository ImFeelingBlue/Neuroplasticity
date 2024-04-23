using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuntPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject AuntPaperPanel;
    [SerializeField] GameObject AuntPaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        AuntPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (AuntPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            AuntPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            AuntPaperPanel.SetActive(true);
            Destroy(AuntPaperPlaceHolderText);
        }
    }
}
