using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour{    
    [SerializeField] private float thrust = 4;
    [SerializeField] private float knockTime = 0.2f;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D other) {

        // if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player")) {
        //     other.GetComponent<Pot>().Smash();
        // }

        // Debug.Log("Who: " + otherTag);
        if(other.gameObject.CompareTag(otherTag) && other.isTrigger) {
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();

            if(hit != null) {
                Vector3 diff = hit.transform.position - transform.position;
                diff = thrust * diff.normalized;
                hit.DOMove(hit.transform.position + diff, knockTime);

                if(other.gameObject.CompareTag("enemy") && other.isTrigger) {
                    // Debug.Log("hit enemy");
                    hit.GetComponent<Enemy>().ChangeState(EnemyState.stagger);
                    other.GetComponentInParent<Enemy>().Knock(hit, knockTime);
                }

                // if(other.gameObject.CompareTag("Player") && other.isTrigger) {
                //     if(hit.GetComponent<Player>().currentState != PlayerState.stagger) {
                //         Debug.Log("hit player");
                //         hit.GetComponent<Player>().currentState = PlayerState.stagger;
                //         other.GetComponentInParent<Player>().Knock(knockTime);
                //     }
                // }
            }
        }
    }
}
