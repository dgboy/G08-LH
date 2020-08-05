using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private ReceiveItem myItem;
    [SerializeField] private float WeaponAttackDuration;
    private Vector2 tempMovement = Vector2.down;
    private Vector3 facingDirection = Vector2.down;

    [SerializeField] private GenericAbility currentAbility;

    void Start() {
        myState.ChangeState(GenericState.idle);
    }

    void Update() {
        if (!IsRestrictedState(myState.myState)) {
            GetInput();
            SetAnimation();
        }
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
        } else if (Input.GetButtonDown("Weapon 2")) {
            if (currentAbility) {
                StartCoroutine(AbilityCo(currentAbility.duration));
            }
            // tempMovement.x = Input.GetAxisRaw("Horizontal");
            // tempMovement.y = Input.GetAxisRaw("Vertical");
            // Motion(tempMovement);
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
                return;
            }
        }
    }

    void SetAnimation() {
        if (tempMovement.magnitude > 0) {
            anim.SetAnimParameter("moveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("moveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("moving", true);
            SetState(GenericState.walk);
            facingDirection = tempMovement;
        } else {
            anim.SetAnimParameter("moving", false);
            if(myState.myState != GenericState.attack) {
                SetState(GenericState.idle);
            }
        }
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

    public IEnumerator WeaponCo() {
        myState.ChangeState(GenericState.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(WeaponAttackDuration);
        myState.ChangeState(GenericState.idle);
        anim.SetAnimParameter("attacking", false);
    }

    private IEnumerator AbilityCo(float duration) {
        myState.ChangeState(GenericState.ability);
        currentAbility.Ability(transform.position, facingDirection, anim.anim, myRigidbody);
        yield return new WaitForSeconds(duration);
        myState.ChangeState(GenericState.idle);
    }

    bool IsRestrictedState(GenericState curState) {
        if(curState == GenericState.attack || curState == GenericState.ability) {
            return true;
        }
        return false;
    }
}
