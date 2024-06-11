using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
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
    public GameObject selectedShader;
    public bool thisItemSelected;

    // Reference to the InventoryManager script
    private InventoryManager inventoryManagerScript;

    // Dictionary to store item sprites
    [SerializeField] private Sprite boxSprite;
    [SerializeField] private Sprite cameraSprite;
    [SerializeField] private Sprite sewingKitSprite;
    [SerializeField] private Sprite pipeSprite;
    [SerializeField] private Sprite syringSprite;
    [SerializeField] private Sprite shovelSprite;
    [SerializeField] private Sprite eyeBallsSprite;
    [SerializeField] private Sprite corpseHeartSprite;
    [SerializeField] private Sprite emptySlotSprite;

    void Start()
    {
        // Find and store a reference to the InventoryManager script
        inventoryManagerScript = GameObject.Find("PlayerUI").GetComponent<InventoryManager>();
    }

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
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
            isFull = true;
            return extraItems;
        }
        else
        {
            // Update the quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
        }

        // Store the item name and description
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        // Set the item image based on the item name
        SetItemImage();

        return 0;
    }

    void SetItemImage()
    {
        switch (itemName)
        {
            case "Box":
                itemImage.sprite = boxSprite;
                break;
            case "Camera":
                itemImage.sprite = cameraSprite;
                break;
            case "Sewing Kit":
                itemImage.sprite = sewingKitSprite;
                break;
            case "Pipe1":
            case "Pipe2":
            case "Pipe3":
                itemImage.sprite = pipeSprite;
                break;
            case "Syring":
                itemImage.sprite = syringSprite;
                break;
            case "Shovel":
                itemImage.sprite = shovelSprite;
                break;
            case "Eye Balls":
                itemImage.sprite = eyeBallsSprite;
                break;
            case "Corpse Heart":
                itemImage.sprite = corpseHeartSprite;
                break;
            default:
                itemImage.sprite = emptySlotSprite;
                break;
        }

        itemImage.enabled = true;
    }

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.enabled = false;
        itemName = "";
        itemDescription = "";
        selectedShader.SetActive(false);
        thisItemSelected = false;
    }
}