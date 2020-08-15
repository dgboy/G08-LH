using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : PowerUp {
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            Health health = other.gameObject.GetComponentInChildren<Health>();
            health.IncreaseMaxHealth();

            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }
}
