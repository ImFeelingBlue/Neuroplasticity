using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Define colors for different types of items
    Color boxColor = new Color(84f / 255f, 0f / 255f, 18f / 255f, 1f);
    Color cameraColor = new Color(0f, 112f / 255f, 192f / 255f, 1f);
    Color emptySlotColor = new Color(101f / 255f, 101f / 255f, 101f / 255f, 1f);

    // Static variable to track if a mouse left click occurred
    public static bool mouseLeftClick;

    // Properties to store item information
    public string itemName;
    public int quantity;
    public bool isFull;
    public string itemDescription;

    // Maximum number of items that can be stored in this slot
    [SerializeField] int maxNumberOfItems;

    // References to UI elements
    [SerializeField] TMP_Text quantityText;
    [SerializeField] Image itemImage;
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;
    public GameObject selectedShader;
    public bool thisItemSelected;

    // Reference to the InventoryManager script
    private InventoryManager inventoryManagerScript;

    // Called when the GameObject is first enabled
    private void Start()
    {
        // Find and store a reference to the InventoryManager script
        inventoryManagerScript = GameObject.Find("PlayerUI").GetComponent<InventoryManager>();
    }

    // Method to add items to the slot
    public int AddItem(string itemName, int quantity, string itemDescription)
    {
        // If the slot is already full, return the remaining quantity
        if (isFull)
        {
            return quantity;
        }

        // Increment the quantity of items in the slot
        this.quantity += quantity;

        // If the slot is now full, adjust the quantity and return any excess items
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;

            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
            return extraItems;
        }
        else if (this.quantity < maxNumberOfItems)
        {
            // Update the quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
        }

        // Store the item name and description
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        if (itemName == "Box")
        {
            itemImage.color = boxColor;
            itemImage.enabled = true;
        }
        else if (itemName == "Camera")
        {
            itemImage.color = cameraColor;
            itemImage.enabled = true;
        }

        // Return zero to indicate that all items were added successfully
        return 0;
    }

    // Method called when the pointer is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the left mouse button was clicked
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Call the left-click handler
            OnLeftClick();
        }
        // Check if the right mouse button was clicked
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Call the right-click handler
            OnRightClick();
        }
    }

    // Handler for left mouse button click
    public void OnLeftClick()
    {
        if (thisItemSelected) 
        {
            inventoryManagerScript.UseItem(itemName);
        }

        // Set the mouse left click flag to true
        mouseLeftClick = true;

        // Deselect all other slots in the inventory
        inventoryManagerScript.DeselectAllSlots();

        // Activate the selected shader to highlight the current slot
        selectedShader.SetActive(true);
        thisItemSelected = true;

        // Display the item name and description in the description panel
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;

        // Set the item description image color based on the item type
        if (itemName == "Box")
        {
            itemDescriptionImage.color = boxColor;
            itemDescriptionImage.enabled = true;
        }
        else if (itemName == "Camera")
        {
            itemDescriptionImage.color = cameraColor;
            itemDescriptionImage.enabled = true;
        }
        else if (itemName == "")
        {
            itemDescriptionImage.color = emptySlotColor;
            itemDescriptionImage.enabled = true;
        }
    }

    // Handler for right mouse button click (not implemented in this code)
    public void OnRightClick()
    {
        // This method can be used to handle right-click actions, such as using or dropping items
    }
}
