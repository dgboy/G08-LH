using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    public float step = 4.0f;
    public float speed = .4f;
    private Rigidbody2D rigid;
    
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        rigid.MovePosition(transform.position + new Vector3(Random.Range(-1, 2) * step, Random.Range(-1, 2) * step, 0f) * Time.deltaTime);
        StartCoroutine(WalkingCo());
    }

    private IEnumerator WalkingCo() {
        yield return new WaitForSeconds(speed);
    }
}
