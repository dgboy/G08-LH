using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable {
    [SerializeField] private string text;
    [SerializeField] private Notification dialogNotification;
    [SerializeField] private StringValue dialogBoxMessege;
    // public GameObject dialogBox;
    // public Text dialogText;

    public virtual void Update() {
        if(playerInRange) {
            if(Input.GetButtonDown("Check") && Time.timeScale == 0f) {
                Time.timeScale = 1f;
                dialogNotification.Raise();
            } else if(Input.GetButtonDown("Check")) {
                Time.timeScale = 0f;
                dialogBoxMessege.value = text;
                dialogNotification.Raise();
            }
        }
    }
}
