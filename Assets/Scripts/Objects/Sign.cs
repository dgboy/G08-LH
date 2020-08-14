using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable {
    [SerializeField] private string text;
    [SerializeField] private Notification dialogNotification = null;
    [SerializeField] private StringValue dialogBoxMessege = null;

    public virtual void StartDialog() {
        if(playerInRange) {
            if(Time.timeScale == 0f) {
                Time.timeScale = 1f;
                dialogNotification.Raise();
            } else {
                Time.timeScale = 0f;
                dialogBoxMessege.value = text;
                dialogNotification.Raise();
            }
        }
    }
}
