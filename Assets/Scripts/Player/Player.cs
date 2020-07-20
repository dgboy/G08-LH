using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class Player : MonoBehaviour {

    private Vector3 movement;
    public PlayerState currentState;
    private Rigidbody2D myRigid;
    private Animator animator;
    public float speed = 15.0f;

    public FloatValue currentHealth;
    public GameSignal healthSignal;
    public VectorValue startPosition;
    public Inventory playerInventory;
    public SpriteRenderer reseiveItemSprite;
    public GameSignal painSignal;

    [Header("Invulnerable Frames")]
    public Color flash;
    public Color regular;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D trigger;
    public SpriteRenderer mySprite;

    void Start() {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigid = GetComponent<Rigidbody2D>();

        transform.position = startPosition.initialValue;

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update() {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger) {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk || currentState != PlayerState.stagger && currentState != PlayerState.interact) {
            Move();
        }
    }

    void Move() {
        if(movement != Vector3.zero) {
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
        // Избавляемся от ускорения ходьбы по диагонали 
        movement.Normalize();
        
        myRigid.MovePosition(
            transform.position + movement * speed * Time.deltaTime
        );
    }

    public void Knock(Rigidbody2D myRigid, float knockTime, float damage) {
        currentHealth.runtimeValue -= damage;
        healthSignal.Raise();

        if(currentHealth.runtimeValue > 0) {
            StartCoroutine(KnockCo(knockTime));
        } else {
            this.gameObject.SetActive(false);
        }
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
    private IEnumerator KnockCo(float knockTime) {
        painSignal.Raise();

        if(myRigid != null) {
            StartCoroutine(FlashCo()); 
            yield return new WaitForSeconds(knockTime);

            currentState = PlayerState.idle;
            myRigid.velocity = Vector2.zero;
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
}
