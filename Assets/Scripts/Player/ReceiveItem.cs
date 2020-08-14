using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private PlayerStateMachine myState = null;
    [SerializeField] private Notification dialogNotification = null;
    [SerializeField] private bool isActive = false;

    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private StringValue itemDescription = null;

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
