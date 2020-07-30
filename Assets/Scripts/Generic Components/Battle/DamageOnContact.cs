using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : Damage {
    [SerializeField] StringValue otherTag;
    [SerializeField] private int damageAmount;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value)) {
            Health health = other.gameObject.GetComponent<Health>();
            if (health) {
                ApplyDamage(health, damageAmount);
            }
        }
    }
}
