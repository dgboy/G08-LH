using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour {
    [Header("Variables from the item")]
    // public Sprite itemSprite;
    // public int numberHeld;
    // public string itemDescription;
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    public void Setup(InventoryItem newItem, InventoryManager newManager) {
        thisItem = newItem;
        thisManager = newManager;

        if (thisItem) {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    } 

    void Start() {
        
    }
}
