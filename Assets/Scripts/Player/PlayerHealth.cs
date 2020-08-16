using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private FlashColor flash;
    [SerializeField] private Notification healthNotif;
    [SerializeField] private GameObject deathEffect = null;
    [SerializeField] private Notification inputCancel = null;

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
        // Destroy(this.transform.parent.gameObject);
        Destroy(effect, 1f);
        // inputCancel.Raise();
        // StartCoroutine();
    }

    // void OpenMenu() {
    //     inputCancel.Raise();
    // }
}
