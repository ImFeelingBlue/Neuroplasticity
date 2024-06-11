using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject DescriptionMenu;
    [SerializeField] CameraMovement CameraMovementScript;

    // Array to store item slots
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    void Start()
    {
        if (CameraMovementScript == null)
        {
            Debug.LogError("CameraMovement script not found on player GameObject.");
            return;
        }

        // Activate inventory menu at the start
        InventoryMenu.SetActive(true);
        DescriptionMenu.SetActive(false);

        // Allow cursor to be visible when inventory is open
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // No need to toggle visibility based on input now
    }

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                return itemSOs[i].UseItem();
            }
        }
        return false;
    }

    public int AddItem(string itemName, int quantity, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemDescription);
                return leftOverItems > 0 ? leftOverItems : 0;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        foreach (var slot in itemSlot)
        {
            slot.selectedShader.SetActive(false);
            slot.thisItemSelected = false;
        }
    }
}