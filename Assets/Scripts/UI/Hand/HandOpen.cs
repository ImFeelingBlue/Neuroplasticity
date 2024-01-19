using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandOpen : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    private int handCount;

    private void Start()
    {
        hand.SetActive(false);
    }

    private void Update()
    {
        ToggleHand();
    }

    private void ToggleHand()
    {
        if (hand != null && Input.GetKeyDown(KeyCode.Q) && handCount == 0)
        {
            hand.SetActive(true);
            handCount = 1;
        }
        else if (hand != null && Input.GetKeyDown(KeyCode.Q) && handCount == 1)
        {
            hand.SetActive(false);
            handCount = 0;
        }
    }
}
