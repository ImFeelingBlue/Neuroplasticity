using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] 
    private string itemName;

    [SerializeField] 
    private int quantity;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        if (inventoryManagerScript == null)
        {
            inventoryManagerScript = GameObject.Find("PlayerUI").GetComponent<InventoryManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inventoryManagerScript.AddItem(itemName, quantity, itemDescription);
            Destroy(gameObject);
        }
    }
}
