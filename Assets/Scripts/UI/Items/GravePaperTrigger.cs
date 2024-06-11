using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravePaperTrigger : MonoBehaviour
{
     [SerializeField] GameObject Player;
    [SerializeField] GameObject GravePaperPanel;
    [SerializeField] GameObject GravePaperPlaceHolderText;
    private bool lockIt;

    private void Start()
    {
        GravePaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (GravePaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            GravePaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            GravePaperPanel.SetActive(true);
            Destroy(GravePaperPlaceHolderText);
        }
    }
}
