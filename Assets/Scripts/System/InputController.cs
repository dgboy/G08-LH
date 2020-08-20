using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Sends user input to the correct control systems.
/// </summary>
public class InputController : MonoBehaviour {
    [SerializeField] private Notification inputCheck = null;
    [SerializeField] private Notification inputInventory = null;
    [SerializeField] private Notification inputCancel = null;

    public enum State {
        Player,
        ListMenu,
        Inventory
    }
    private State state;

    public void ChangeState(State state) => this.state = state;

    void Update() {
        switch (state) {
            case State.Player:
                PlayerControl();
                break;
            case State.ListMenu:
                ListMenuControl();
                break;
            case State.Inventory:
                InventoryControl();
                break;
        }
    }

    void PlayerControl() {
        
    }

    void ListMenuControl() {
        
    }

    void InventoryControl() {
        
    }


    public void OnMove(InputAction.CallbackContext context) {
        // tempMovement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) {
        // myState.Attacking();
    }
    public void OnAbility(InputAction.CallbackContext context) {
        // myState.AbilityUse(currentAbility, myRigidbody);
    }
    public void OnCheck(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        // Debug.Log(myState.myState);
        // if (myState.myState == State.receiveItem) {
        //     myItem.ChangeSpriteState();
        //     return;
        // } else {
        //     inputCheck.Raise();
        // }
    }
    public void OnInventory(InputAction.CallbackContext context) {
        inputInventory.Raise();
    }
    public void OnPause(InputAction.CallbackContext context) {
        inputCancel.Raise();
    }
}
