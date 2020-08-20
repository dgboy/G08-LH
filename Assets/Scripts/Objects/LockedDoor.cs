using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Interactable {
    public virtual void Open() {
        this.gameObject.SetActive(false);
        isBlocked = true;
    }

    public void Close() {
        this.gameObject.SetActive(true);
        isBlocked = false;
    }
}
