using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    idle,
    walk,
    stun,
    dying,
    attack,
    receiveItem,
    ability
}

public class PlayerStates : MonoBehaviour {
    public State myState;
    [SerializeField] private PlayerMagic playerMagic = null;
    private Vector3 facingDir = Vector2.down;
    private float weaponAttackDuration = .2f;
    private Animator myAnimator;

    void Start() {
        ChangeState(State.idle);
        myAnimator = GetComponentInParent<Animator>();
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
        // Debug.Log("Idling!");
        if (myState != State.attack) {
            myAnimator.SetBool("moving", false);
            ChangeState(State.idle);
        }
    }

    public void Walking(Vector2 movement) {
        if (myState != State.stun) {
            ChangeState(State.walk);
            facingDir = movement;

            myAnimator.SetBool("moving", true);
            myAnimator.SetFloat("moveX", Mathf.Round(movement.x));
            myAnimator.SetFloat("moveY", Mathf.Round(movement.y));
        }
    }

    public void Stunning() {
        ChangeState(State.stun);
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
        // Debug.Log(myAnimator.GetBool("attacking"));
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
}
