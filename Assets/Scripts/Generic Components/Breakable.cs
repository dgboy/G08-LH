using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {
    [SerializeField] private StringValue otherTag;
    private float breakDelay = .3f;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void Smash() {
        animator.SetBool("smashing", true);
        StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo() {
        yield return new WaitForSeconds(breakDelay);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && other.isTrigger) {
            Smash();
        }
    }
}
