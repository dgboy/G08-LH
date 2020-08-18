﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private Notification dialogNotification = null;

    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private StringValue itemDescription = null;
    private bool isActive = false;
    private SpriteRenderer mySprite;

    void Start() {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.enabled = false;
    }

    // public void ChangeSpriteState() {
    //     // Debug.Log(isActive);
    //     isActive = !isActive;
    //     if (isActive) {
    //         DisplaySprite();
    //     } else {
    //         DisableSprite();
    //     }
    // }

    public void DisplaySprite() {
        mySprite.enabled = true;
        mySprite.sprite = playerInventory.receiveItem.itemImage;
        itemDescription.value = playerInventory.receiveItem.itemDescription;
        dialogNotification.Raise();
    }

    public void DisableSprite() {
        playerInventory.receiveItem = null;
        mySprite.enabled = false;
        dialogNotification.Raise();
    }
}
