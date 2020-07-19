using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walking,
    attacking,
    stagger
}

public class Enemy : MonoBehaviour {

    public FloatValue maxHealth;
    public string nameEnemy = "Unknown";
    public int attackDamage = 1;
    public float moveSpeed = 1.5f;
    public GameObject deathEffect;
    public float deathEffectDelay = 1f;
    
    protected EnemyState currentState;
    protected float health;



    void Awake() {
        health = maxHealth.initialValue;
    }

    public void TakeDamage(float damage) {
        health -= damage;

        if(health <= 0) {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeState(EnemyState newState) {
        if(currentState != newState) {
            currentState = newState;
        }
    }
    public void Knock(Rigidbody2D myRigid, float knockTime, float damage) {
        TakeDamage(damage);
        
        if(this.health > 0) {
            StartCoroutine(KnockCo(myRigid, knockTime));
        }
    }

    private IEnumerator KnockCo(Rigidbody2D myRigid, float knockTime) {
        if(myRigid != null) {
            yield return new WaitForSeconds(knockTime);

            currentState = EnemyState.idle;
            myRigid.velocity = Vector2.zero;
        }
    }

    private void DeathEffect() {
        if(deathEffect != null) {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
}
