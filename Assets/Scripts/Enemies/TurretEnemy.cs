﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Log {
    public GameObject projectile;
    public float fireDelay = .8f;
    private float fireDelaySeconds;
    public bool canFire = true;

    private void Update() {
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0) {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }    
    }

    protected override void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius
        ) {
            if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                if (canFire) {
                Vector3 tempVector = target.transform.position - transform.position;
                GameObject current = Instantiate(projectile, transform.position, Quaternion.identity); 
                current.GetComponent<Projectile>().Launch(tempVector);
                canFire = false;

                ChangeState(EnemyState.walking);
                animator.SetBool("wakeUp", true);
                }
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
            //ChangeState(EnemyState.idle);
            animator.SetBool("wakeUp", false);
        }
        base.CheckDistance();                               
    }

    // void Start() {
        
    // }

    // void Update() {

    // }
}