using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour {
    [SerializeField] private StringValue otherTag = null;
    [SerializeField] private float knockTime = 0.1f;
    [SerializeField] private float knockStrength = 1f;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && other.isTrigger) {
            Rigidbody2D body = other.GetComponentInParent<Rigidbody2D>();
            if (!body) {
                return;
            }

            Vector2 dir = other.transform.position - transform.position;
            Vector2 movement = (Vector2)other.transform.position + (dir.normalized * knockStrength);
            body.DOMove(movement, knockTime);
        }
    }
}
