using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement {
    [SerializeField] private PlayerStateMachine myState = null;
    [SerializeField] private ReceiveItem myItem = null;
    [SerializeField] private GenericAbility currentAbility = null;
    [SerializeField] private Notification inputCheck = null;
    [SerializeField] private Notification inputInventory = null;
    [SerializeField] private Notification inputCancel = null;
    [SerializeField] private float weaponAttackDuration = .1f;

    private Animator myAnimator;
    private Vector2 tempMovement = Vector2.down;
    private Vector3 facingDirection = Vector2.down;


    public void OnMove(InputAction.CallbackContext context) {
        tempMovement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) {
        StartCoroutine(WeaponCo());
        tempMovement = Vector2.zero;
        Motion(tempMovement);
    }
    public void OnAbility(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        if (currentAbility && !IsRestrictedState(myState.myState)) {
            StartCoroutine(AbilityCo(currentAbility.duration));
        }
    }
    public void OnCheck(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        Debug.Log(myState.myState);

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
        myAnimator = GetComponentInParent<Animator>();
        myState.ChangeState(State.idle);
        tempMovement = Vector2.zero;
    }

    void FixedUpdate() {
        if (!IsRestrictedState(myState.myState)) {
            Motion(tempMovement);
            SetAnimation();
        }
    }


    void SetState(State newState) {
        myState.ChangeState(newState);
    }

    void SetAnimation() {
        if (tempMovement.magnitude > 0) {
            myAnimator.SetFloat("moveX", Mathf.Round(tempMovement.x));
            myAnimator.SetFloat("moveY", Mathf.Round(tempMovement.y));
            myAnimator.SetBool("moving", true);
            SetState(State.walk);
            facingDirection = tempMovement;
        } else {
            myAnimator.SetBool("moving", false);
            if (myState.myState != State.attack) {
                SetState(State.idle);
            }
        }
    }

    public IEnumerator WeaponCo() {
        myState.ChangeState(State.attack);
        myAnimator.SetBool("attacking", true);
        yield return new WaitForSeconds(weaponAttackDuration);
        myState.ChangeState(State.idle);
        myAnimator.SetBool("attacking", false);
    }

    private IEnumerator AbilityCo(float duration) {
        myState.ChangeState(State.ability);
        currentAbility.Ability(transform.position, facingDirection, myAnimator, myRigidbody);
        yield return new WaitForSeconds(duration);
        myState.ChangeState(State.idle);
    }

    bool IsRestrictedState(State curState) {
        if (curState == State.attack || curState == State.ability || curState == State.receiveItem) {
            return true;
        }
        return false;
    }
}
