using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour {
    public PlayerInventory playerInventory;
    public InventoryItem currentItem;

    [Header("Inventory Information")]
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;

    void Start() {
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    void SetTextAndButton(string description, bool buttonActive) {
        descriptionText.text = description;
        itemNameText.text = description;
        if (buttonActive) {
            useButton.SetActive(true);
        } else {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots() {
        if(playerInventory) {
            for (int i = 0; i < playerInventory.myInventory.Count; i++) {
                if (playerInventory.myInventory[i].numberHeld > 0) {
                    GameObject temp = Instantiate(
                        blankInventorySlot, 
                        inventoryPanel.transform.position, 
                        Quaternion.identity
                    );

                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                    if (newSlot) {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    public void SetupDesciptionAndButton(string newDescription, string newItemNameText, bool isButtonUsable, InventoryItem newItem) {
        currentItem = newItem;
        descriptionText.text = newDescription;
        itemNameText.text = newItemNameText;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed() {
        if (currentItem) {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlots();
        }
    }

    void ClearInventorySlots() {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++) {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
}
