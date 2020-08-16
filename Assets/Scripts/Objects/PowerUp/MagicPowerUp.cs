using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp {
    public int magicValue;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
            PlayerMagic magicPower = other.gameObject.GetComponentInChildren<PlayerMagic>();
            Debug.Log(magicPower);
            magicPower.RestoreMagic(magicValue);

            powerUpNotif.Raise();
            Destroy(this.gameObject);
        }
    }
}
