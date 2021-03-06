﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlayerState {
    idle,
    walk,
    attack,
    interact,
    stagger, 
    ability
}

public class PlayerOld : MonoBehaviour {
    public PlayerState currentState;
    public float speed = 15.0f;
    
    public VectorValue startPosition;
    public Inventory playerInventory;
    public SpriteRenderer reseiveItemSprite;
    
    [Header("Projectile Stuff")]
    public GameObject projectile;
    public Notification decreaseMagic;
    public Item Bow;

    [Header("Invulnerable Frames")]
    public Notification painSignal;
    public Color flash;
    public Color regular;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D trigger;
    public SpriteRenderer mySprite;

    [SerializeField] private GenericAbility currentAbility = null;
    private Vector3 facingDirection = Vector2.down;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private Vector3 movement;

    void Start() {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = startPosition.value;

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(
            Input.GetButtonDown("Attack") 
            && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger
        ) {
            StartCoroutine(AttackCo());
        } else if(
            Input.GetButtonDown("Weapon 2") 
            && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger
        ) {
            // if(currentAbility) {
            //     StartCoroutine(AbilityCo(currentAbility.duration));
            // }
        } else if(
            currentState == PlayerState.walk 
            || currentState != PlayerState.stagger 
            && currentState != PlayerState.interact
        ) {
            Move();
        }

    }

    void Move() {
        if(movement != Vector3.zero) {
            movement.x = Mathf.Round(movement.x);
            movement.y = Mathf.Round(movement.y);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
        // Избавляемся от ускорения ходьбы по диагонали 
        movement.Normalize();
        
        rigidbody.MovePosition(
            transform.position + movement * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTime) {
        StartCoroutine(KnockCo(knockTime));
    }

    public void RaiseItem() {
        if (currentState != PlayerState.interact) {
            animator.SetBool("receive_item", true);
            currentState = PlayerState.interact;
            reseiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
        } else {
            animator.SetBool("receive_item", false);
            currentState = PlayerState.idle;
            reseiveItemSprite.sprite = null;
        }
    }

    private void MakeArrow() {
        if (playerInventory.currentMagic > 0) {
            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(temp, ChooseArrowDirection());
            playerInventory.DecreaseMagic(arrow.magicCost);
            Debug.Log("Shot!");
            decreaseMagic.Raise();
        }
    }

    Vector3 ChooseArrowDirection() {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }


    private IEnumerator AttackCo() {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact) {
            currentState = PlayerState.walk;
        }
    }
    private IEnumerator SecondAttackCo() {
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact) {
            currentState = PlayerState.walk;
        }
    }
    private IEnumerator KnockCo(float knockTime) {
        painSignal.Raise();
        if(rigidbody != null) {
            StartCoroutine(FlashCo()); 
            yield return new WaitForSeconds(knockTime);
            currentState = PlayerState.idle;
            rigidbody.velocity = Vector2.zero;
        }
    }
    private IEnumerator FlashCo() {
        int temp = 0;
        trigger.enabled = false;

        while(temp < numberOfFlashes) {
            mySprite.color = flash;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regular;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }

        trigger.enabled = true;
    }
    // private IEnumerator AbilityCo(float duration) {
    //     facingDirection = movement;
    //     currentAbility.Use(transform.position, facingDirection, animator, rigidbody);
    //     // if (currentAbility) {
    //     // } else {
    //     //     yield return null;
    //     // }
    //     currentState = PlayerState.ability;
    //     yield return new WaitForSeconds(duration);
    //     currentState = PlayerState.idle;
    // }

    bool IsRestrictedState(PlayerState curState) {
        if(curState == PlayerState.attack || curState == PlayerState.ability) {
            return true;
        }
        return false;
    }
}
