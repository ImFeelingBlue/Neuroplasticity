using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SewingKitPaperTrigger : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject SewingKitPaperPanel;
    [SerializeField] GameObject gabrielHouseDoorCube;
    private bool lockIt;

    private void Start()
    {
        SewingKitPaperPanel.SetActive(false);
        lockIt = false;
    }

    private void Update()
    {
        if (SewingKitPaperPanel.activeSelf && Input.GetKeyDown(KeyCode.Tab))
        {
            SewingKitPaperPanel.SetActive(false);
            lockIt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !lockIt)
        {
            SewingKitPaperPanel.SetActive(true);
            Destroy(gabrielHouseDoorCube);
        }
    }
}
