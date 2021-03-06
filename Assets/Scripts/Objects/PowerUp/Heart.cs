﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp {
    public int healPower;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(otherTag.value) && !other.isTrigger) {
            Health health = other.gameObject.GetComponentInChildren<Health>();
            health.Heal(healPower);

            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }
}
