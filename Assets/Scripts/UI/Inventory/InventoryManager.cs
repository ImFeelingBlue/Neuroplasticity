using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // References to UI elements
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject DescriptionMenu;
    [SerializeField] CameraMovement CameraMovementScript;

    // Flag to track if the inventory menu is activated
    public bool menuActivated = false;

    // Array to store item slots
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    // Reference to the ItemSlot script
    [SerializeField] private ItemSlot ItemSlotScript;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the CameraMovementScript is assigned
        if (CameraMovementScript == null)
        {
            Debug.LogError("CameraMovement script not found on player GameObject.");
            return;
        }

        // Deactivate inventory and description menus at start
        InventoryMenu.SetActive(false);
        DescriptionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check the visibility of the inventory menu
        InventoryVisability();
    }

    // Method to handle inventory menu visibility
    public void InventoryVisability()
    {
        // Toggle inventory menu visibility based on input and current state
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            DeselectAllSlots();
            CameraMovementScript.isPaused = false;
            menuActivated = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            CameraMovementScript.isPaused = true;
            InventoryMenu.SetActive(true);
            menuActivated = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Toggle description menu visibility based on mouse left click and inventory menu state
        if (ItemSlot.mouseLeftClick == true && InventoryMenu.activeSelf)
        {
            DescriptionMenu.SetActive(true);
        }
        else if (!InventoryMenu.activeSelf)
        {
            DescriptionMenu.SetActive(false);
            ItemSlot.mouseLeftClick = false;
        }
    }

    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }
        }
    }

    // Method to add items to the inventory
    public int AddItem(string itemName, int quantity, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            // Check if the item slot is not full and matches the item name, or if it's empty
            if (itemSlot[i].isFull == false && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                // Add the item to the slot
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemDescription);
                // Return any leftover items if added successfully
                if (leftOverItems > 0)
                {
                    return leftOverItems;
                }
                else
                {
                    return 0;
                }
            }
        }
        // Return remaining quantity if no suitable slot is found
        return quantity;
    }

    // Method to deselect all item slots in the inventory
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
