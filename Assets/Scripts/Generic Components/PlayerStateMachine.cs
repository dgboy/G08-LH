using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    idle,
    walk,
    attack,
    stun,
    dying,
    receiveItem,
    ability
}

public class PlayerStateMachine : MonoBehaviour {
    public State myState;
    private Animator animator;

    public void ChangeState(State newState) {
        if(myState != newState) {
            myState = newState;
        }
    }

    void Start() {
        ChangeState(State.idle);
        animator = GetComponentInParent<Animator>();
    }

    public void Idling() {
        Debug.Log("Idling!");
        animator.SetBool("moving", false);
        ChangeState(State.idle);
    }

    public void Walking(Vector2 movement) {
        if (myState != State.stun) {
            ChangeState(State.walk);
            animator.SetBool("moving", true);
            animator.SetFloat("moveX", Mathf.Round(movement.x));
            animator.SetFloat("moveY", Mathf.Round(movement.y));
        }
    }

    public void Stunning() {
        ChangeState(State.stun);
    }

    // Attacking State
    public void Attacking() {
        if(myState == State.walk && myState != State.stun) {
            StartCoroutine(AttackCo());
        }
    }
    public IEnumerator AttackCo() {
        ChangeState(State.attack);
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);

        ChangeState(State.walk);
        animator.SetBool("attack", false);
    }
}
