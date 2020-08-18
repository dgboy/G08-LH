using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerMovement : Movement {
    [SerializeField] private GenericAbility currentAbility = null;
    [SerializeField] private ReceiveItem myItem = null;
    [SerializeField] private PlayerMagic playerMagic = null;
    [SerializeField] private Notification inputCheck = null;
    [SerializeField] private Notification inputInventory = null;
    [SerializeField] private Notification inputCancel = null;
    
    // [SerializeField] private State myState = null;
    private State myState;
    private float weaponAttackDuration = .2f;
    private Animator myAnimator;
    private Vector3 facingDir = Vector2.down;
    private Vector2 tempMovement = Vector2.down;

    public Animator MyAnimator { get => myAnimator; set => myAnimator = value; }

    void Start() {
        tempMovement = Vector2.zero;
        ChangeState(State.idle);
        myAnimator = GetComponentInParent<Animator>();
    }

    void FixedUpdate() {
        Motion(tempMovement);
        if (tempMovement.magnitude > 0) {
            Walking(tempMovement);
        } else {
            Idling();
        }
    }

    public void ChangeState(State newState) {
        if (myState != newState) {
            myState = newState;
        }
    }

    public bool IsRestrictedState() {
        return 
            myState == State.attack ||
            myState == State.ability ||
            myState == State.receiveItem;
    }

    public void Idling() {
        if (!IsRestrictedState()) {
            myAnimator.SetBool("moving", false);
            ChangeState(State.idle);
        }
    }

    public void Walking(Vector2 movement) {
        facingDir = movement;
        
        if (myState != State.stun && !IsRestrictedState()) {
            ChangeState(State.walk);
            myAnimator.SetBool("moving", true);
            myAnimator.SetFloat("moveX", Mathf.Round(movement.x));
            myAnimator.SetFloat("moveY", Mathf.Round(movement.y));
        }
    }

    public void Stunning() {
        ChangeState(State.stun);
    }

    public void ReceivingItem() {
        if (!IsRestrictedState()) {
            ChangeState(State.receiveItem);
            myAnimator.SetBool("receive_item", true);
        } else {
            ChangeState(State.idle);
            myAnimator.SetBool("receive_item", false);
        }
    }

    // Attacking State
    public void Attacking() {
        if (!IsRestrictedState()) {
            StartCoroutine(AttackCo());
        }
    }

    public void AbilityUse(GenericAbility ability, Rigidbody2D myRigidbody) {
        if (ability && !IsRestrictedState()) {
            StartCoroutine(AbilityCo(ability, myRigidbody));
        }
    }


    // Coroutines
    private IEnumerator AttackCo() {
        ChangeState(State.attack);
        myAnimator.SetBool("attacking", true);
        yield return new WaitForSeconds(weaponAttackDuration);
        ChangeState(State.idle);
        myAnimator.SetBool("attacking", false);
    }

    private IEnumerator AbilityCo(GenericAbility ability, Rigidbody2D myRigidbody) {
        ChangeState(State.ability);
        ability.Use(playerMagic, transform.position, facingDir, myAnimator, myRigidbody);
        yield return new WaitForSeconds(ability.duration);
        ChangeState(State.idle);
    }



    public void OnMove(InputAction.CallbackContext context) {
        tempMovement = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context) {
        Attacking();
    }
    public void OnAbility(InputAction.CallbackContext context) {
        AbilityUse(currentAbility, myRigidbody);
    }
    public void OnCheck(InputAction.CallbackContext context) {
        if (!context.started) {
            return;
        }
        if (!IsRestrictedState()) {
            inputCheck.Raise();
        } else {
            myItem.ChangeSpriteState();
        }
    }
    public void OnInventory(InputAction.CallbackContext context) {
        inputInventory.Raise();
    }
    public void OnPause(InputAction.CallbackContext context) {
        inputCancel.Raise();
    }
}
