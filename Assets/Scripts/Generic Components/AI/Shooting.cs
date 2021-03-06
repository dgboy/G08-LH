﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Sleeping {
    [SerializeField] private GenericAbility ability = null;
    [SerializeField] private Magic magic = null;
    private bool canFire = true;

    // protected override void CheckDistance() {
    //     if(
    //         Vector3.Distance(target.position, transform.position) <= chaseRadius &&
    //         Vector3.Distance(target.position, transform.position) > attackRadius
    //     ) {
    //         if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
    //             if (canFire) {
    //                 Debug.Log(canFire);
    //                 Vector3 tempVector = target.transform.position - transform.position;
    //                 GameObject current = Instantiate(projectile, transform.position, Quaternion.identity); 
    //                 Debug.Log(current.name);
    //                 current.GetComponent<Projectile>().Launch(tempVector);
    //                 canFire = false;

    //                 ChangeState(EnemyState.walking);
    //                 animator.SetBool("wakeUp", true);
    //             }
    //         }
    //     }
    //     else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
    //         animator.SetBool("wakeUp", false);
    //     }
    //     // base.CheckDistance();                               
    // }

    public override void FollowingTarget() {
        if (InChaseRadius) {
            // WakeUp();
            Walking(target.position);
            if (canFire) {
                StartCoroutine(AbilityCo(ability.duration));
            }
        } else {
            Idle();
        }
    }

    private IEnumerator AbilityCo(float duration) {
        // myState.ChangeState(State.ability);
        canFire = false;
        ability.Use(magic, transform.position, target.position - transform.position, null, null);
        yield return new WaitForSeconds(duration);
        canFire = true;
        // myState.ChangeState(State.idle);
    }
}