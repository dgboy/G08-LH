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

    [Header("Projectile Stuff")]
    public GameObject projectile;
    public GameSignal decreaseMagic;
    public Item Bow;


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
            if (playerInventory.CheckForItem(Bow)) {
                StartCoroutine(SecondAttackCo());
            }
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
