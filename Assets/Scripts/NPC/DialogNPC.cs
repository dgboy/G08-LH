using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable {
    [SerializeField] private TextAsset myDialog = null;
    [SerializeField] private DialogAssetValue dialogValue = null;
    [SerializeField] private Notification branchingDialogNotification = null;
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
