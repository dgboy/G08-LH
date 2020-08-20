using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour {
    public FloatValue playerHealth;
    public Notification healhSignal;

    public void Use(int amountToIncrease) {
        playerHealth.value += amountToIncrease;
        healhSignal.Raise();
    }
}
