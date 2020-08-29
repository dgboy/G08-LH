using UnityEngine; 

[RequireComponent(typeof(Rigidbody2D))]
public class GenericProjectile : MonoBehaviour {
    [SerializeField] [Range(10f, 20f)] private float speed = 10f; 
    private new Rigidbody2D rigidbody;

    void OnEnable() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 moveDir) {
        rigidbody.velocity = moveDir.normalized * speed;
    }
}