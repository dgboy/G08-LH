using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakingUpAndFollowing : Movement {
    [SerializeField] private StringValue targetTag;
    [SerializeField] private float chaseRadius;
    [SerializeField] private StateMachine myState;
    private Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag(targetTag.value).GetComponent<Transform>();
    }

    void FixedUpdate() {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if(targetDistance < chaseRadius) {
            if (!myState.IsAwakened) {
                myState.WakingUp();
                return;
            }
            Vector2 movement = (Vector2)(target.position - transform.position);
            myState.Walking(movement);
            Motion(movement);
        }  else {
            Motion(Vector2.zero);
            myState.FallingAsleep();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
