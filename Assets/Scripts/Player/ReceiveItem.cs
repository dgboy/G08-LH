using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private PlayerStateMachine myState;
    [SerializeField] private bool isActive = false;
    [SerializeField] private Notification dialogNotification;

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private StringValue itemDescription;

    void Start() {
        mySprite.enabled = false;
    }

    public void ChangeSpriteState() {
        Debug.Log(isActive);
        isActive = !isActive;
        if (isActive) {
            DisplaySprite();
        } else {
            DisableSprite();
        }
    }

    void DisplaySprite() {
        myState.ChangeState(GenericState.receiveItem);
        anim.SetAnimParameter("receive_item", true);
        mySprite.enabled = true;

        mySprite.sprite = playerInventory.receiveItem.itemImage;
        itemDescription.value = playerInventory.receiveItem.itemDescription;
        dialogNotification.Raise();
    }

    void DisableSprite() {
        playerInventory.receiveItem = null;
        myState.ChangeState(GenericState.idle);
        mySprite.enabled = false;
        dialogNotification.Raise();
    }
}
