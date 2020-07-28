using UnityEngine;

public class DamageOnContact : MonoBehaviour {
    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(otherTag) && other.isTrigger) {
            Debug.Log("Projectile!");
            GenericHealth temp = other.gameObject.GetComponent<GenericHealth>();
            if (temp) {
                temp.Damage(damage);
            }
            Destroy(this.gameObject);
        }
    }
    // public override void OnTriggerEnter2D(Collider2D other) {
    //     base.OnTriggerEnter2D(other);
    //     Debug.Log("Projectile!");
    //     Destroy(this.gameObject);
    // }
}
