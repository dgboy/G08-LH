using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : Movement {

    [SerializeField] private StringValue targetTag;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    private Transform target;
    private float targetDistance;

    void Start() {
        target = GameObject.FindGameObjectWithTag(targetTag.value).GetComponent<Transform>();
    }

    void FixedUpdate() {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if(targetDistance < chaseRadius && targetDistance > attackRadius) {
            Vector2 temp = (Vector2)(target.position - transform.position);
            Motion(temp);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
