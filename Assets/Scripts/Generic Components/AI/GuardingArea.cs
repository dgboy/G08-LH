using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardingArea : Sleeping {
    [SerializeField] private Collider2D area;
    public bool TargetInBoundary => area.bounds.Contains(target.transform.position);

    public override void FollowingTarget() {
        // Debug.Log("TargetInBoundary: " + TargetInBoundary);
        if(InChaseRadius && TargetInBoundary) {
            Walking(target.position);
        } else if(!InChaseRadius || !TargetInBoundary) {
            Idle();
        }
    } 
}
