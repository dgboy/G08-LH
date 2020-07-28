﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed;
    public Vector2 directionToMove;
    public Rigidbody2D myRigidbody;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 initialVel) {
        myRigidbody.velocity = initialVel * moveSpeed;
    }
}
