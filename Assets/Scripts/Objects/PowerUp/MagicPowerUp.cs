using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp {
    public FloatValue playerMP;
    public float magicValue;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            playerMP.value += magicValue;
            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }
}
