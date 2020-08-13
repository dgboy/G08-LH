using UnityEngine; 

[RequireComponent(typeof(Rigidbody2D))]
public class GenericProjectile : MonoBehaviour {
    [SerializeField] private float speed; 
    private Rigidbody2D rigidbody; 

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 moveDir) {
        rigidbody.velocity = moveDir.normalized * speed;
    }
}