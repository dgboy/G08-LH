using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement {
    [SerializeField] private PlayerStates myState = null;
    [SerializeField] private GenericAbility currentAbility = null;
    [SerializeField] private ReceiveItem myItem = null;
    [SerializeField] private Notification inputCheck = null;
    [SerializeField] private Notification inputInventory = null;
    [SerializeField] private Notification inputCancel = null;
    private Vector2 tempMovement = Vector2.down;


    public void OnMove(InputAction.CallbackContext context) {
        tempMovement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) {
        myState.Attacking();
    }
    public void OnAbility(InputAction.CallbackContext context) {
        myState.AbilityUse(currentAbility, myRigidbody);
    }
    public void OnCheck(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        // Debug.Log(myState.myState);
        if (myState.myState == State.receiveItem) {
            myItem.ChangeSpriteState();
            return;
        } else {
            inputCheck.Raise();
        }
    }
    public void OnInventory(InputAction.CallbackContext context) {
        inputInventory.Raise();
    }
    public void OnPause(InputAction.CallbackContext context) {
        inputCancel.Raise();
    }


    void Start() {
        tempMovement = Vector2.zero;
    }

    void FixedUpdate() {
        Motion(tempMovement);
        if (!myState.IsRestrictedState()) {
            if (tempMovement.magnitude > 0) {
                myState.Walking(tempMovement);
            } else {
                myState.Idling();
            }
        } else {
            tempMovement = Vector2.zero;
        }
    }
}
