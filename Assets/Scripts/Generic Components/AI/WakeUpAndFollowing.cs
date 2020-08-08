using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpAndFollowing : Following {
    public bool IsAwakened => Animator.GetBool("wakeUp");

    public override void Idle() {
        Motion(Vector2.zero);
        Animator.SetBool("wakeUp", false);
        base.Idle();
        // MyState.FallingAsleep();
    }

    public override void Walking(Vector3 followTarget) {
        // StartCoroutine(MoveCo());
        if (!IsAwakened) {
            Animator.SetBool("wakeUp", true);
            // MyState.WakingUp();
        } else {
            base.Walking(followTarget);
        }
    }
}
