using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChurchAnimations : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] private GameObject intactBody;

    [SerializeField] private GameObject Corpse1;
    [SerializeField] private GameObject Corpse2;
    [SerializeField] private GameObject Corpse3;
    [SerializeField] private GameObject Corpse4;
    [SerializeField] private GameObject Corpse5;
    [SerializeField] private GameObject Corpse6;
    [SerializeField] private GameObject Corpse7;
    [SerializeField] private GameObject Corpse8;
    [SerializeField] private GameObject Corpse9;
    [SerializeField] private GameObject Corpse10;
    [SerializeField] private GameObject Corpse11;

    private bool leverAnimation = false;
    private bool crossDestruction = false;

    // Start is called before the first frame update
    void Start()
    {
        if (intactBody != null)
        {
            intactBody.SetActive(true);

            Corpse1.SetActive(false);
            Corpse2.SetActive(false);
            Corpse3.SetActive(false);
            Corpse4.SetActive(false);
            Corpse5.SetActive(false);
            Corpse6.SetActive(false);
            Corpse7.SetActive(false);
            Corpse8.SetActive(false);
            Corpse9.SetActive(false);
            Corpse10.SetActive(false);
            Corpse11.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && Input.GetKeyDown(KeyCode.E))
        {
            leverAnimation = true;
            crossDestruction = true;
        }
    }
}
