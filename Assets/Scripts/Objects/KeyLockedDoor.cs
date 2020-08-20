using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockedDoor : LockedDoor {
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private InventoryItem rightKey;

    public override void Open() {
        if (playerInRange && inventory.myInventory.Contains(rightKey)) {
            rightKey.DecreaseAmount();
            base.Open();
        }
    }
}
