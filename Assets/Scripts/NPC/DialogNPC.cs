using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable {
    [SerializeField] private TextAsset myDialog;
    [SerializeField] private DialogAssetValue dialogValue;
    [SerializeField] private Notification branchingDialogNotification;
	private bool isTalking = false;

    public void StartDialog() {
        if (playerInRange && !isTalking) {
            isTalking = true;
            dialogValue.value = myDialog;
            branchingDialogNotification.Raise();
            clue.Raise();
        }
    }


}
