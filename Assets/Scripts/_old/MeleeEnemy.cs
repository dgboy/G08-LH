using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Log {
    void Start() {
        health = maxHealth.value;
        homePosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected override void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius
        ) {
            if(
                currentState == EnemyState.idle 
                || currentState == EnemyState.walking 
                && currentState != EnemyState.stagger
            ) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                rigidbody.MovePosition(temp);
                ChangeWalkAnimation(temp - transform.position);
                ChangeState(EnemyState.walking);
            }
        }
        else if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) <= attackRadius
        ) {
            if(currentState == EnemyState.walking && currentState != EnemyState.stagger) {
            StartCoroutine(AttackCo());
            }
        }
    }

    public IEnumerator AttackCo() {
        currentState = EnemyState.attacking;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);

        currentState = EnemyState.walking;
        animator.SetBool("attack", false);
    }
}
