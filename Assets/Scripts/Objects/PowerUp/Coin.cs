using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp {
    public PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(otherTag.value) && !other.isTrigger) {
            
            playerInventory.Coins++;

            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }

}
