using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private FlashColor flash = null;
    [SerializeField] private Notification healthNotif = null;
    [SerializeField] private GameObject deathEffect = null;

    public override void Damage(int damage) {
        base.Damage(damage);
        healthNotif.Raise();

        if(IsAlive) {
            if (flash) {
                flash.StartFlash();
            }
        } else {
            Die();
        }
    }

    void Die() {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        this.transform.parent.gameObject.SetActive(false);
        Destroy(effect, 1f);
        // Destroy(this.transform.parent.gameObject);
    }
}
