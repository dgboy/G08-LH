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
    
    private State myState;
    private Animator myAnimator;
    private float weaponAttackDuration = .2f;
    private Vector3 facingDir = Vector2.down;
    private Vector2 tempMovement = Vector2.down;

    void Start() {
        tempMovement = Vector2.zero;
        ChangeState(State.idle);
        myAnimator = GetComponentInParent<Animator>();
    }

    void Update() {
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

    public bool IsReceiveItem => myState == State.receiveItem;

    public Vector2 TempMovement { get => tempMovement; set => tempMovement = value; }

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
        // myItem.ChangeSpriteState();
        if (!IsRestrictedState()) {
            ChangeState(State.receiveItem);
            myItem.DisplaySprite();
            myAnimator.SetBool("receive_item", true);
        } else {
            ChangeState(State.idle);
            myItem.DisableSprite();
            myAnimator.SetBool("receive_item", false);
        }
    }

    // Attacking State
    public void Attacking() {
        if (!IsRestrictedState()) {
            StartCoroutine(AttackCo());
        }
    }

    public void UseAbility() {
        if (currentAbility && !IsRestrictedState()) {
            StartCoroutine(AbilityCo(currentAbility, myRigidbody));
        }
    }


    // Coroutines
    private IEnumerator AttackCo() {
        ChangeState(State.attack);
        myAnimator.SetBool("attacking", true);
        yield return new WaitForSeconds(weaponAttackDuration);
        myAnimator.SetBool("attacking", false);
        ChangeState(State.idle);
    }

    private IEnumerator AbilityCo(GenericAbility ability, Rigidbody2D myRigidbody) {
        ChangeState(State.ability);
        ability.Use(playerMagic, transform.position, facingDir, myAnimator, myRigidbody);
        yield return new WaitForSeconds(ability.duration);
        ChangeState(State.idle);
    }
}
