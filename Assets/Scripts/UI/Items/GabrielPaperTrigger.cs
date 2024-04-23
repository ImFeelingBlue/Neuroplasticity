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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tabCount++;
            Debug.Log(tabCount);
        }
        if (GabrielPaperPanel1.activeSelf && tabCount == 1)
        {
            if (tabCount == 2)
            {
                GabrielPaperPanel1.SetActive(false);
                GabrielPaperPanel2.SetActive(true);
            }
            else if (tabCount == 3)
            {
                GabrielPaperPanel2.SetActive(false);
                GabrielPaperPanel3.SetActive(true);
            }
            else if (tabCount == 4)
            {
                GabrielPaperPanel3.SetActive(false);
                GabrielPaperPanel4.SetActive(true);
            }
            else if (tabCount == 5)
            {
                GabrielPaperPanel4.SetActive(false);
                GabrielPaperPanel5.SetActive(true);
            }
            else if (tabCount == 6)
            {
                GabrielPaperPanel5.SetActive(false);
                lockIt = true;
            }
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
