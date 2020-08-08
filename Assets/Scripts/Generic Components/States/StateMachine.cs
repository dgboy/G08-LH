using System.Collections;
using UnityEngine;


public class StateMachine : MonoBehaviour {
    [SerializeField] private Animator animator;
    private State currentState;

    private enum State {
        idle,
        walking,
        attacking,
        stunning
    }

    void ChangeState(State newState) => currentState = newState;

    void Start() {
        ChangeState(State.idle);
    }

    public void Idling() {
        Debug.Log("Idling!");
        animator.SetBool("moving", false);
        ChangeState(State.idle);
    }

    public void Walking(Vector2 movement) {
        if (currentState != State.stunning) {
            ChangeState(State.walking);
            animator.SetBool("moving", true);
            animator.SetFloat("moveX", Mathf.Round(movement.x));
            animator.SetFloat("moveY", Mathf.Round(movement.y));
        }
    }

    public void Stunning() {
        ChangeState(State.stunning);
    }

    // Attacking State
    public void Attacking() {
        if(currentState == State.walking && currentState != State.stunning) {
            StartCoroutine(AttackCo());
        }
    }
    public IEnumerator AttackCo() {
        ChangeState(State.attacking);
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);

        ChangeState(State.walking);
        animator.SetBool("attack", false);
    }

    // WakingUp State
    public bool IsAwakened => animator.GetBool("wakeUp");
    public void WakingUp() {
        Debug.Log("wakeup!");
        // ChangeState(State.stunning);
        animator.SetBool("wakeUp", true);
    }
    public void FallingAsleep() {
        animator.SetBool("wakeUp", false);
        Idling();
    }
}
