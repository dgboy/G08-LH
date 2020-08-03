using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum EnemyState {
//     idle,
//     walk,
//     attack,
//     stun
// }

public class SimpleFollow : Movement {

    [SerializeField] private StringValue targetTag;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    private Transform target;
    private float targetDistance;

    [SerializeField] private AnimatorController anim;
    // [SerializeField] private StateMachine myState;

    void Start() {
        target = GameObject.FindGameObjectWithTag(targetTag.value).GetComponent<Transform>();
    }

    void FixedUpdate() {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance > attackRadius && targetDistance < chaseRadius) {
            Vector2 temp = (Vector2)(target.position - transform.position);

            // if (!anim.GetAnimBool("wakeUp")) {
            // }

            Motion(temp);
            SetAnimation(temp);
        } else {
            SetAnimation(Vector2.zero);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    void SetAnimation(Vector2 temp) {
        if (temp.magnitude > 0) {
            // anim.SetBool("wakeUp", true);
            
            anim.SetAnimParameter("wakeUp", true);
            // if(anim.GetAnimBool(wakeUp)) {

            // }
            anim.SetAnimParameter("moveX", Mathf.Round(temp.x));
            anim.SetAnimParameter("moveY", Mathf.Round(temp.y));
            anim.SetAnimParameter("moving", true);
            // SetState(GenericState.walk);
        } else {
            anim.SetAnimParameter("moving", false);
            anim.SetAnimParameter("wakeUp", false);
            // if(myState.myState != GenericState.attack) {
            //     SetState(GenericState.idle);
            // }
        }
    }
}
