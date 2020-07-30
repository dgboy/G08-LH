using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private ReceiveItem myItem;
    [SerializeField] private float WeaponAttackDuration;
    private Vector2 tempMovement = Vector2.down;

    void Start() {
        myState.ChangeState(GenericState.idle);
    }

    void Update() {
        GetInput();
        SetAnimation();
    }


    void SetState(GenericState newState) {
        myState.ChangeState(newState);
    }


    void GetInput() {
        if (
            Input.GetButtonDown("Attack")
            && myState.myState != GenericState.attack
        ) {
            StartCoroutine(WeaponCo());
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        } else if (myState.myState != GenericState.attack) {
            tempMovement.x = Input.GetAxisRaw("Horizontal");
            tempMovement.y = Input.GetAxisRaw("Vertical");
            Motion(tempMovement);
        } else {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }

        if(myState.myState == GenericState.receiveItem) {
            if(Input.GetButtonDown("Check")) {
                myState.ChangeState(GenericState.idle);
                anim.SetAnimParameter("receiveItem", false);
                myItem.ChangeSpriteState();
            }
            return;
        }
    }

    void SetAnimation() {
        if (tempMovement.magnitude > 0) {
            anim.SetAnimParameter("moveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("moveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("moving", true);
            SetState(GenericState.walk);
        } else {
            anim.SetAnimParameter("moving", false);
            if(myState.myState != GenericState.attack) {
                SetState(GenericState.idle);
            }
        }
    }

    public IEnumerator WeaponCo() {
        myState.ChangeState(GenericState.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(WeaponAttackDuration);

        myState.ChangeState(GenericState.idle);
        anim.SetAnimParameter("attacking", false);
    }
}
