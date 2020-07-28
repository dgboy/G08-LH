using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour {
    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(otherTag) && other.isTrigger) {
            GenericHealth temp = other.gameObject.GetComponent<GenericHealth>();
            if (temp) {
                temp.Damage(damage);
            }
        Debug.Log("Projectile!");
        }
    }
}
