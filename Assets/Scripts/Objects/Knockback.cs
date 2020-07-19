using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour{    
    public int thrust = 4;
    public float knockTime = 0.2f;
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player")) {
            other.GetComponent<Pot>().Smash();
        }

        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")) {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();

            if(hit != null) {

                Vector2 diff = hit.transform.position - transform.position;
                diff = thrust * diff.normalized;
                hit.AddForce(diff, ForceMode2D.Impulse);

                if(other.gameObject.CompareTag("Player")) {
                    if(other.GetComponent<Player>().currentState != PlayerState.stagger) {
                        hit.GetComponent<Player>().currentState = PlayerState.stagger;
                        other.GetComponent<Player>().Knock(hit, knockTime, damage);
                    }
                }

                if(other.gameObject.CompareTag("enemy")) {
                    hit.GetComponent<Enemy>().ChangeState(EnemyState.stagger);
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
            }
        }
    }
}
