using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private float speed;
    protected Rigidbody2D myRigidbody;

    void OnEnable() {
        myRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public void Motion(Vector2 direction) {
        direction = direction.normalized;
        myRigidbody.velocity = direction * speed;
    }
}
