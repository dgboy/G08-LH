using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUpAndAttacking : Following {
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelay = .5f;

    public bool InAttackRadius => DistanceToTarget < attackRadius;

    public override void FollowingTarget() {
        if(InAttackRadius) {
            Attack();
            // Vector2 movement = (Vector2)(target.position - transform.position);
            // Motion(movement);
        }
        base.FollowingTarget();
    }

    protected void Attack() {
            StartCoroutine(AttackCo());
    }

    public IEnumerator AttackCo() {
        Animator.SetBool("attack", true);
        yield return new WaitForSeconds(attackDelay);
        Animator.SetBool("attack", false);
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
