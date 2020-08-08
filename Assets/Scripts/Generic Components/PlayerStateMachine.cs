using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenericState {
    idle,
    walk,
    attack,
    stun,
    dead,
    receiveItem,
    ability
}

public class PlayerStateMachine : StateMachine {
    public GenericState myState;

    public void ChangeState(GenericState newState) {
        if(myState != newState) {
            myState = newState;
        }
    }
}
