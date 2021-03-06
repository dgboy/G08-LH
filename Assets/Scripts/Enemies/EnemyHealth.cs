﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] private LootTable thisLoot = null;
    [SerializeField] private Notification questNotif = null;

    public override void Damage(int damage) {
        base.Damage(damage);

        if (!IsAlive) {
            // Debug.Log("Die!");
            Die();
        }
    }

    void Die() {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        this.transform.parent.gameObject.SetActive(false);
        Destroy(effect, 1f);
        // Destroy(this.transform.parent.gameObject);
        MakeLoot();
        if (questNotif) {
            questNotif.Raise();
        }
    }

    private void MakeLoot() {
        if (thisLoot) {
            PowerUp current = thisLoot.LootPowerUp();
            if (current) {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
