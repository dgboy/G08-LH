using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUpAndAttacking : Movement {
    [SerializeField] private StringValue targetTag;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private StateMachine myState;
    private Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag(targetTag.value).GetComponent<Transform>();
    }

    void FixedUpdate() {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if(targetDistance > attackRadius && targetDistance < chaseRadius) {
            Vector2 movement = (Vector2)(target.position - transform.position);
            myState.Walking(movement);
            Motion(movement);
        } else if(targetDistance <= attackRadius && targetDistance < chaseRadius) {
            Vector2 movement = (Vector2)(target.position - transform.position);
            myState.Attacking();
            Motion(movement);
        } else {
            // myState.Walking(Vector2.zero);
            Motion(Vector2.zero);
            myState.Idling();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
