using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {
    public GameSignal clue;
    protected bool playerInRange = false;
    protected bool blocked = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(IsPlayer(other) && !blocked) {
            clue.Raise();
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(IsPlayer(other) && !blocked) {
            clue.Raise();
            playerInRange = false;
        }
    }

    protected bool IsPlayer(Collider2D other) =>
        other.CompareTag("Player") && !other.isTrigger;
}
