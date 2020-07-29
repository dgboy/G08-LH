﻿using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour {
    [SerializeField] private InventoryItem thisItem;
    [SerializeField] private PlayerInventory playerInventory;

    void AddItemToInventory() {
        if(playerInventory && thisItem) {
            if (playerInventory.myInventory.Contains(thisItem)) {
                thisItem.numberHeld += 1;
            } else {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !other.isTrigger) {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
}