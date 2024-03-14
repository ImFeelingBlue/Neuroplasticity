using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Serialized fields to store item information
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    // Reference to the InventoryManager script
    private InventoryManager inventoryManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the InventoryManager script
        if (inventoryManagerScript == null)
        {
            inventoryManagerScript = GameObject.Find("PlayerUI").GetComponent<InventoryManager>();
        }
    }

    // Called when a collider enters the trigger zone of this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.tag == "Player")
        {
            // Attempt to add the item to the player's inventory
            int leftOverItems = inventoryManagerScript.AddItem(itemName, quantity, itemDescription);

            // If there are no leftover items after adding, destroy the item GameObject
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            // If there are leftover items, update the quantity field
            else
            {
                quantity = leftOverItems;
            }
        }
    }
}
