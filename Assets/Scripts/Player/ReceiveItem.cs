using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerStateMachine myState;
    [SerializeField] private Notification dialogNotification;
    [SerializeField] private bool isActive = false;

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private StringValue itemDescription;

    void Start() {
        mySprite.enabled = false;
    }

    public void ChangeSpriteState() {
        // Debug.Log(isActive);
        isActive = !isActive;
        if (isActive) {
            DisplaySprite();
        } else {
            DisableSprite();
        }
    }

    void DisplaySprite() {
        myState.ChangeState(State.receiveItem);
        animator.SetBool("receive_item", true);
        // Debug.Log(myState.myState);
        
        mySprite.enabled = true;

        mySprite.sprite = playerInventory.receiveItem.itemImage;
        itemDescription.value = playerInventory.receiveItem.itemDescription;
        dialogNotification.Raise();
    }

    void DisableSprite() {
        playerInventory.receiveItem = null;
        myState.ChangeState(State.idle);
        animator.SetBool("receive_item", false);
        mySprite.enabled = false;
        dialogNotification.Raise();
    }
}
