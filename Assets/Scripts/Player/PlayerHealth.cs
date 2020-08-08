using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    [SerializeField] private FlashColor flash;

    public override void Damage(int damage) {
        base.Damage(damage);
        if(IsAlive) {
            if (flash) {
                flash.StartFlash();
            }
        }
    }
}
