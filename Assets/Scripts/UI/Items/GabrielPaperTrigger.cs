using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GabrielPaperPanel1;
    [SerializeField] GameObject GabrielPaperPanel2;
    [SerializeField] GameObject GabrielPaperPanel3;
    [SerializeField] GameObject GabrielPaperPanel4;
    [SerializeField] GameObject GabrielPaperPanel5;
    [SerializeField] GameObject GabrielPaperPlaceHolderText;
    private bool lockIt;
    private int tabCount = 0;

    private void Start()
    {
        GabrielPaperPanel1.SetActive(false);
        GabrielPaperPanel2.SetActive(false);
        GabrielPaperPanel3.SetActive(false);
        GabrielPaperPanel4.SetActive(false);
        GabrielPaperPanel5.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if ((GabrielPaperPanel1.activeSelf || GabrielPaperPanel2.activeSelf || GabrielPaperPanel3.activeSelf || GabrielPaperPanel4.activeSelf || GabrielPaperPanel5.activeSelf) && Input.GetKeyDown(KeyCode.Tab))
        {
            tabCount++;
            Debug.Log(tabCount);
        }
        if (GabrielPaperPanel1.activeSelf && tabCount == 1)
        {
            GabrielPaperPanel1.SetActive(false);
            GabrielPaperPanel2.SetActive(true);
        }
        else if (GabrielPaperPanel2.activeSelf && tabCount == 2)
        {
            GabrielPaperPanel2.SetActive(false);
            GabrielPaperPanel3.SetActive(true);
        }
        else if (GabrielPaperPanel3.activeSelf && tabCount == 3)
        {
            GabrielPaperPanel3.SetActive(false);
            GabrielPaperPanel4.SetActive(true);
        }
        else if (GabrielPaperPanel4.activeSelf && tabCount == 4)
        {
            GabrielPaperPanel4.SetActive(false);
            GabrielPaperPanel5.SetActive(true);
        }
        else if (GabrielPaperPanel5.activeSelf && tabCount == 5)
        {
            GabrielPaperPanel5.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            GabrielPaperPanel1.SetActive(true);
            Destroy(GabrielPaperPlaceHolderText);
        }
    }
}
