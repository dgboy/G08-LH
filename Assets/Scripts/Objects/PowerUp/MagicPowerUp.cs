﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUp {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
