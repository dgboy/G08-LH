using UnityEngine;

public class Following : Movement {
    [SerializeField] private StringValue targetTag = null;
    [SerializeField] protected float chaseRadius;
    protected Transform target;
    private Animator animator;

    protected Animator Animator { get => animator; }

    public float DistanceToTarget => Vector3.Distance(transform.position, target.position);
    public bool InChaseRadius => DistanceToTarget < chaseRadius;

    protected virtual void Start() {
        animator = GetComponentInParent<Animator>();
        target = GameObject.FindGameObjectWithTag(targetTag.value).GetComponent<Transform>();
    }

    void FixedUpdate() {
        FollowingTarget();
    }

    public virtual void FollowingTarget() {
        if (InChaseRadius) {
            Walking(target.position);
        } else {
            Idle();
        }
    }

    public virtual void Idle() {
        // Debug.Log("Idling!");
        Motion(Vector2.zero);
        Animator.SetBool("moving", false);
    }

    public virtual void Walking(Vector3 followTarget) {
        Vector2 movement = (Vector2)(followTarget - transform.position);
        Motion(movement);

        Animator.SetBool("moving", true);
        Animator.SetFloat("moveX", Mathf.Round(movement.x));
        Animator.SetFloat("moveY", Mathf.Round(movement.y));
    }

    public void Stunning() {
        // ChangeState(State.stunning);
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
