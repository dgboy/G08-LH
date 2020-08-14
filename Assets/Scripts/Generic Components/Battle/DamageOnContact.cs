using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : Damage {
    [SerializeField] StringValue otherTag = null;
    [SerializeField] private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (IsTarget(other)) {
            MakeDamage(other);
        }
    }

    public void MakeDamage(Collider2D other) {
        Health health = other.gameObject.GetComponent<Health>();
        if (health) {
            ApplyDamage(health, damageAmount);
        }
    }

    public bool IsTarget(Collider2D other) {
        return other.gameObject.CompareTag(otherTag.value);
    }
}
