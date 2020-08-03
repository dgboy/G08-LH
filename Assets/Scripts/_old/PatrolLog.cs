using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log {

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    protected override void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius
        ) {

            if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                rigidbody.MovePosition(temp);

                ChangeWalkAnimation(temp - transform.position);
                ChangeState(EnemyState.walking);
                animator.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
            
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance) {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                rigidbody.MovePosition(temp);
                ChangeWalkAnimation(temp - transform.position);
            } else {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal() {
        currentPoint = (currentPoint == path.Length - 1) ? 0 : currentPoint + 1;
        currentGoal = path[currentPoint];
    }

}
