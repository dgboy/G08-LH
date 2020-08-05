using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable {
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    public virtual void Update() {
        if(playerInRange) {
            if(Input.GetButtonDown("Check") && dialogBox.activeInHierarchy) {
                Time.timeScale = 1f;
                dialogBox.SetActive(false);
            } else if(Input.GetButtonDown("Check") && !dialogBox.activeInHierarchy) {
                Time.timeScale = 0f;
                dialogText.text = dialog;
                dialogBox.SetActive(true);
            }
        }
    }
}
