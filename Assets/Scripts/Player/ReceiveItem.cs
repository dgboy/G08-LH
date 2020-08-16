using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class ReceiveItem : MonoBehaviour {
    [SerializeField] private PlayerStates myState = null;
    [SerializeField] private Notification dialogNotification = null;

    [SerializeField] private PlayerInventory playerInventory = null;
    [SerializeField] private StringValue itemDescription = null;
    private bool isActive = false;
    private SpriteRenderer mySprite;
    private Animator myAnimator;

    void Start() {
        mySprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponentInParent<Animator>();
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
        myAnimator.SetBool("receive_item", true);
        mySprite.enabled = true;

        mySprite.sprite = playerInventory.receiveItem.itemImage;
        itemDescription.value = playerInventory.receiveItem.itemDescription;
        dialogNotification.Raise();
    }

    void DisableSprite() {
        playerInventory.receiveItem = null;
        myState.ChangeState(State.idle);
        myAnimator.SetBool("receive_item", false);
        mySprite.enabled = false;
        dialogNotification.Raise();
    }
}
