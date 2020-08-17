using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType {
    key,
    enemy,
    button
}

public class LockedDoor : Interactable {
    
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    // public SpriteRenderer openDoorSprite;
    public SpriteRenderer closeDoorSprite;
    public BoxCollider2D doorCollider;
    public GameObject door;

    private void Update() {
        if(playerInRange && Input.GetButtonDown("Check")) {
            if(playerInventory.numberOfKeys > 0) {
                Open();
            } else {
                Debug.Log("Closed!");
            }
        }
    }
    public void Open() {
        if (thisDoorType == DoorType.key) {
            playerInventory.numberOfKeys--;
        }

        Debug.Log("Non-active The Doors!");
        door.SetActive(false);
        open = true;
        
        // clue.Raise(); 
        // doorCollider.enabled = false;
        // closeDoorSprite.enabled = false;
        
        // openDoorSprite.enabled = true;
    }
    public void Close() {
        door.SetActive(true);
    }
}
