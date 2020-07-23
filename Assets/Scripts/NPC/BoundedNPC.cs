using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign {
    public Collider2D bounds;
    public float speed;
    public float moveTime;
    public float waitTime;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;

    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private bool isMoving;
    private float moveTimeSeconds;
    private float waitTimeSeconds;

    void Start() {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        myAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    public override void Update() {
        base.Update();
        
        if(isMoving) {
            moveTimeSeconds -= Time.deltaTime;
            if(moveTimeSeconds <= 0) {
                isMoving = false;
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
            }
            if(!playerInRange) {
                Move();
            }
        } else {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0) {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }

    private void ChooseDifferentDirection() {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100) {
            loops++;
            ChangeDirection();
        }
    }

    private void Move() {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp)) {
            myRigidbody.MovePosition(temp);
        } else {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        int direction = Random.Range(0, 4);

        switch(direction) {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation() {
        myAnimator.SetFloat("moveX", directionVector.x);
        myAnimator.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ChooseDifferentDirection();
    }
}
