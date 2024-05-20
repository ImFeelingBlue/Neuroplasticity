using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTheCutscene3Trigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cutscene3Trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (cutscene3Trigger != null)
        {
            cutscene3Trigger.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (cutscene3Trigger != null)
            {
                cutscene3Trigger.SetActive(true);
            }
        }
    }
}
