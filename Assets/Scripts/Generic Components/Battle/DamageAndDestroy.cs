using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndDestroy : DamageOnContact {
    private void OnTriggerEnter2D(Collider2D other) {
        if (IsTarget(other)) {
            HealthDamage(other);
            Destroy(this.gameObject);
        }
    }
}
