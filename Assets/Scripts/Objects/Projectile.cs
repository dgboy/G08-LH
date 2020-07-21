using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed;
    public Vector2 directionToMove;
    [Header("Lifetime")]
    public float lifetime;
    private float lifetimeSeconds;
    public Rigidbody2D myRigidbody;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;    
    }

    void Update() {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVel) {
        myRigidbody.velocity = initialVel * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }
}
