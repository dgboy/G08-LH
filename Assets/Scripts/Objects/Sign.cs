using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactive {
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    void Update() {
        if(playerInRange) {
            if(dialogBox.activeInHierarchy && Input.GetKey(KeyCode.Escape)) {
                dialogBox.SetActive(false);
            } else if(!dialogBox.activeInHierarchy && Input.GetKey(KeyCode.F)){
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
