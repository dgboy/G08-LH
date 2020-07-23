using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactive {
    public float speed;
    public Collider2D bounds;

    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Start() {
        myAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update() {
        if(!playerInRange) {
            Move();
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
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100) {
            loops++;
            ChangeDirection();
        }
    }
}
