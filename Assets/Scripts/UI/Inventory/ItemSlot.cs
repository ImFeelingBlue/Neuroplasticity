using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    Color boxColor = new Color(84f / 255f, 0f / 255f, 18f / 255f, 1f);
    Color cameraColor = new Color(0f, 112f / 255f, 192f / 255f, 1f);

    public static bool mouseLeftClick;

    public string itemName;
    public int quantity;
    public bool isFull;
    public string itemDescription;

    [SerializeField] TMP_Text quantityText;
    [SerializeField] Image itemImage;

    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManagerScript;

    private void Start()
    {
        inventoryManagerScript = GameObject.Find("PlayerUI").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, int quantity, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        mouseLeftClick = true;
        inventoryManagerScript.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionNameText.text = itemDescription;

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
    }

    public void OnRightClick()
    {

    }
}
