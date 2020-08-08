using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour {
    [SerializeField] private StringValue otherTag;
    [SerializeField] private float knockTime;
    [SerializeField] private float knockStrength;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(otherTag.value) && other.isTrigger) {
            Rigidbody2D body = other.GetComponentInParent<Rigidbody2D>();
            if (body) {
                Vector2 dir = other.transform.position - transform.position;
                body.DOMove((Vector2)other.transform.position + (dir.normalized * knockStrength), knockTime);
            }
        }
    }
}
