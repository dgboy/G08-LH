using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : Magic {
    [SerializeField] private Notification magicNotif;

    public override void UseMagic(int amount) {
        base.UseMagic(amount);
        magicNotif.Raise();
    }
}
