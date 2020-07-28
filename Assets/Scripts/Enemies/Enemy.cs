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

    [Header("Characteristics")]
    public string nameEnemy = "Unknown";
    public FloatValue maxHealth;
    public int attackDamage = 1;
    public float moveSpeed = 1.5f;
    public Vector2 homePosition;
    public GameSignal roomSignal;
    public LootTable thisLoot;
    
    [Header("Death Effects")]
    public GameObject deathEffect;
    protected float deathEffectDelay = 1f;

    protected float health;
    protected EnemyState currentState;


    protected void Awake() {
        health = maxHealth.initialValue;
        homePosition = transform.position;
    }

    protected void OnEnable() {
        health = maxHealth.initialValue;
        transform.position = homePosition;
        currentState = EnemyState.idle;
    }

    // public void TakeDamage(float damage) {
    //     Debug.Log("Damage!");
    //     health -= damage;

    //     if(health <= 0) {
    //         DeathEffect();
    //         MakeLoot();
    //         this.gameObject.SetActive(false);

    //         if (roomSignal) {
    //             roomSignal.Raise();
    //         }
    //     }
    // }

    public void ChangeState(EnemyState newState) {
        if(currentState != newState) {
            currentState = newState;
        }
    }
    public void Knock(Rigidbody2D myRigid, float knockTime) {
        StartCoroutine(KnockCo(myRigid, knockTime));
        // // TakeDamage(damage);
        
        // if(temp.currentHealth > 0) {
        // } else {
        //     DeathEffect();
        //     MakeLoot();
        //     this.gameObject.SetActive(false);

        //     if (roomSignal) {
        //         roomSignal.Raise();
        //     }
        // }
    }

    private IEnumerator KnockCo(Rigidbody2D myRigid, float knockTime) {
        if(myRigid != null) {
            yield return new WaitForSeconds(knockTime);

            currentState = EnemyState.idle;
            myRigid.velocity = Vector2.zero;
        }
    }

    private void MakeLoot() {
        if(thisLoot != null) {
            PowerUp current = thisLoot.LootPowerUp();
            if (current != null) {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void DeathEffect() {
        if(deathEffect != null) {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
}
