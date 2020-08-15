using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private FlashColor flash;
    [SerializeField] private Notification healthNotif;

    public override void Damage(int damage) {
        base.Damage(damage);
        healthNotif.Raise();

        if(IsAlive) {
            if (flash) {
                flash.StartFlash();
            }
        } else {
            // GameObject parent = GameObject
        }
    }
}
