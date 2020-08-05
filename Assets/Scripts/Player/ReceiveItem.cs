using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private SpriteValue receivedSprite;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private bool isActive = false;
    [SerializeField] private Notification dialogNotification;

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
        myState.ChangeState(GenericState.receiveItem);
        mySprite.enabled = true;
        mySprite.sprite = receivedSprite.value;
        anim.SetAnimParameter("receiveItem", true);
        dialogNotification.Raise();
    }


    void DisableSprite() {
        myState.ChangeState(GenericState.idle);
        mySprite.enabled = false;
        dialogNotification.Raise();

    }

    // public void RaiseItem() {
    //     if (myState.myState != GenericState.receiveItem) {
    //         anim.SetAnimParameter("receiveItem", true);
    //             myState.ChangeState(GenericState.receiveItem);
    //         // animator.SetBool("receive_item", true);
    //         // currentState = PlayerState.interact;
    //         reseiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
    //     } else {
    //         anim.SetAnimParameter("receiveItem", false);
    //         // animator.SetBool("receive_item", false);
    //         currentState = PlayerState.idle;
    //         reseiveItemSprite.sprite = null;
    //     }
    // }
}
