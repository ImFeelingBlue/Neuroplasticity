using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject DescriptionMenu;
    [SerializeField] CameraMovement CameraMovementScript;
    public bool menuActivated = false;
    public ItemSlot[] itemSlot;

    [SerializeField] private ItemSlot ItemSlotScript;
    void Start()
    {

        if (CameraMovementScript == null)
        {
            Debug.LogError("CameraMovement script not found on player GameObject.");
            return;
        }

        InventoryMenu.SetActive(false);
        DescriptionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryVisability();
    }

    public void InventoryVisability()
    {
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

    public void AddItem(string itemName, int quantity, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
