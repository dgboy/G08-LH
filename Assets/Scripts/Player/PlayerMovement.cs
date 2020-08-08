﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {
    [SerializeField] private AnimatorController anim;
    [SerializeField] private PlayerStateMachine myState;
    [SerializeField] private ReceiveItem myItem;
    [SerializeField] private float WeaponAttackDuration;
    private Vector2 tempMovement = Vector2.down;
    private Vector3 facingDirection = Vector2.down;

    [SerializeField] private GenericAbility currentAbility;

    void Start() {
        myState.ChangeState(State.idle);
    }

    void Update() {
        if (!IsRestrictedState(myState.myState)) {
            if(myState.myState == State.receiveItem) {
                if(Input.GetButtonDown("Check")) {
                    myState.ChangeState(State.idle);
                    anim.SetAnimParameter("receive_item", false);
                    myItem.ChangeSpriteState();
                }
                return;
            }

            GetInput();
            SetAnimation();
        }
    }


    void SetState(State newState) {
        myState.ChangeState(newState);
    }


    void GetInput() {
        if (Input.GetButtonDown("Attack")) {
            StartCoroutine(WeaponCo());
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        } else if (Input.GetButtonDown("Weapon 2")) {
            if (currentAbility) {
                StartCoroutine(AbilityCo(currentAbility.duration));
            }
            // tempMovement.x = Input.GetAxisRaw("Horizontal");
            // tempMovement.y = Input.GetAxisRaw("Vertical");
            // Motion(tempMovement);
        } else if (myState.myState != State.attack) {
            tempMovement.x = Input.GetAxisRaw("Horizontal");
            tempMovement.y = Input.GetAxisRaw("Vertical");
            Motion(tempMovement);
        } else {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
    }

    void SetAnimation() {
        if (tempMovement.magnitude > 0) {
            anim.SetAnimParameter("moveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("moveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("moving", true);
            SetState(State.walk);
            facingDirection = tempMovement;
        } else {
            anim.SetAnimParameter("moving", false);
            if(myState.myState != State.attack) {
                SetState(State.idle);
            }
        }
    }

    public IEnumerator WeaponCo() {
        myState.ChangeState(State.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(WeaponAttackDuration);
        myState.ChangeState(State.idle);
        anim.SetAnimParameter("attacking", false);
    }

    private IEnumerator AbilityCo(float duration) {
        myState.ChangeState(State.ability);
        currentAbility.Ability(transform.position, facingDirection, anim.anim, myRigidbody);
        yield return new WaitForSeconds(duration);
        myState.ChangeState(State.idle);
    }

    bool IsRestrictedState(State curState) {
        if(curState == State.attack || curState == State.ability) {
            return true;
        }
        return false;
    }
}
