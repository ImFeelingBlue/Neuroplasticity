using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableTheCutsene2Trigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cutscene2Trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (cutscene2Trigger != null)
        {
            cutscene2Trigger.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (cutscene2Trigger != null)
            {
                cutscene2Trigger.SetActive(true);
            }
        }
    }
}
