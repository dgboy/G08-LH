using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : Interactable {
    [SerializeField] private StringValue dialogBoxMessege = null;

    protected override void OnTriggerEnter2D(Collider2D other) {
        if (!isBlocked) {
            if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
                dialogBoxMessege.value = "На улице такая чудестная погода, не плохо было быйти погулять.";
                // clue.Raise();
                isBlocked = true;
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other) {
        // if (!isBlocked) {
        //     if (other.gameObject.CompareTag(otherTag.value) && !other.isTrigger) {
        //         dialogBoxMessege.value = "";
        //         clue.Raise(); 
        //         isBlocked = true;
        //     }
        // }
    }
}
