using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp {
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float healPower;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger) {
            playerHealth.runtimeValue += healPower;

            if(playerHealth.runtimeValue > heartContainers.runtimeValue * 2f) {
                playerHealth.runtimeValue = heartContainers.runtimeValue * 2f;
            }

            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
