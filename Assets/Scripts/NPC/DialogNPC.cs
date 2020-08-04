﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable {
    [SerializeField] private TextAsset myDialog;
    [SerializeField] private DialogAssetValue dialogValue;
    [SerializeField] private Notification branchingDialogNotification;

    void Start() {
        
    }

    void Update() {
        if (playerInRange) {
            if(Input.GetButtonDown("Check")) {
                dialogValue.value = myDialog;
                branchingDialogNotification.Raise();
                clue.Raise();
            }
        }
    }
}
