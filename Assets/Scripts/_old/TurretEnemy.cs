using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Log {
    public GameObject projectile;
    public float fireDelay = .8f;
    private float fireDelaySeconds;
    public bool canFire = true;

    private void Update() {
        if (!canFire) {
            fireDelaySeconds -= Time.deltaTime;
            if (fireDelaySeconds <= 0) {
                canFire = true;
                fireDelaySeconds = fireDelay;
            }    
        }    
    }    

    // private void OnDrawGizmos() {
    //     Gizmos.DrawLine(transform.position, target.position);
    //     Gizmos.DrawWireSphere(transform.position, chaseRadius);
    //     Gizmos.DrawWireSphere(transform.position, attackRadius);
    // }

    protected override void CheckDistance() {
        if(
            Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius
        ) {
            if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger) {
                if (canFire) {
                    Debug.Log(canFire);
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity); 
                    Debug.Log(current.name);
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;

                    ChangeState(EnemyState.walking);
                    animator.SetBool("wakeUp", true);
                }
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
            animator.SetBool("wakeUp", false);
        }
        // base.CheckDistance();                               
    }
}
