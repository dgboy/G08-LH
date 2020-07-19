using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy {

    public float chaseRadius = 4.0f;
    public float attackRadius = 1.2f;

    protected Rigidbody2D rigid;
    protected Animator animator;
    protected Transform target;

    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        currentState = EnemyState.idle;
        animator.SetBool("wakeUp", true);
    }

    void FixedUpdate() {
        CheckDistance();
    }

    protected virtual void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius
        ) {
            if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                rigid.MovePosition(temp);

                ChangeWalkAnimation(temp - transform.position);
                ChangeState(EnemyState.walking);
                animator.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
            //ChangeState(EnemyState.idle);
            animator.SetBool("wakeUp", false);
        }
    }

    protected void ChangeWalkAnimation(Vector2 dir) {
        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y)) {
            if(dir.x > 0) {
                SetWalkAnimFloat(Vector2.right);
            } else if (dir.x < 0) {
                SetWalkAnimFloat(Vector2.left);
            }
        } else if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y)) {
            if(dir.y > 0) {
                SetWalkAnimFloat(Vector2.up);
            } else if (dir.y < 0) {
                SetWalkAnimFloat(Vector2.down);
            }
        }
    }

    private void SetWalkAnimFloat(Vector2 set) {
        animator.SetFloat("moveX", set.x);
        animator.SetFloat("moveY", set.y);
    }
}
