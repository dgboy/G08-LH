using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactive {
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    public virtual void Update() {
        if(playerInRange) {
            if(dialogBox.activeInHierarchy && Input.GetButtonDown("Check")) {
                dialogBox.SetActive(false);
            } else if(!dialogBox.activeInHierarchy && Input.GetButtonDown("Check")) {
                dialogText.text = dialog;
                dialogBox.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(IsPlayer(other)) {
            clue.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
