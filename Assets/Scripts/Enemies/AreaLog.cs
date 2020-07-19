using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLog : Log {
    
    public Collider2D boundary;

    protected override void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius &&
            boundary.bounds.Contains(target.transform.position)
        ) { 
            if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                rigid.MovePosition(temp);

                ChangeWalkAnimation(temp - transform.position);
                ChangeState(EnemyState.walking);
                animator.SetBool("wakeUp", true);
            }
        }
        else if(
            Vector3.Distance(target.position, transform.position) > chaseRadius ||
            !boundary.bounds.Contains(target.transform.position)
        ) {
            animator.SetBool("wakeUp", false);
        }
    } 
}
