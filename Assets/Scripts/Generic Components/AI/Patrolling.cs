using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : WakeUpAndFollowing {
    [SerializeField] private Transform[] points;
    [SerializeField] private float roundingDistance = .1f;
    private int currentPoint = 0;
    private Transform currentGoal;

    public float DistanceToGoal => Vector3.Distance(transform.position, currentGoal.position);
    public bool InPlace => DistanceToGoal > roundingDistance;

    void Start() {
        base.Start();
        currentGoal = points[currentPoint];
    }

    public override void FollowingTarget() {
        if (InChaseRadius) {
            Walking(target.position);
        } else {
            if (InPlace) {
                Walking(currentGoal.position);
            } else {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal() {
        currentPoint = (currentPoint == points.Length - 1) ? 0 : currentPoint + 1;
        currentGoal = points[currentPoint];
    }
}
