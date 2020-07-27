using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth {
    [SerializeField] private GameSignal healthSignal;

    public override void Damage(float amountToDamage) {
        base.Damage(amountToDamage);
        maxHealth.runtimeValue = currentHealth;
        healthSignal.Raise();
    }

    void Start() {
        
    }

    void Update() {
        
    }
}
