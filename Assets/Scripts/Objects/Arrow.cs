﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float speed = 5;
    public Rigidbody2D myRigidbody;

    // void Start() {
    //     myRigidbody = GetComponent<Rigidbody2D>();
    // }

    public void Setup(Vector2 velocity, Vector3 direction) {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("enemy")) {
            Destroy(this.gameObject);
        }
    }

}
