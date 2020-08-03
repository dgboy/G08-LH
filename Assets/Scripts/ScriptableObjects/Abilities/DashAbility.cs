using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dash", menuName = "Scriptable Objects/Abilities/Dash", order = 0)]
public class DashAbility : GenericAbility {
    public float dashForse;

    public override void Ability(
        Vector2 position, Vector2 facingDirection,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        if (rigidbody) {
            Vector3 dashVector = rigidbody.transform.position + (Vector3)facingDirection.normalized * dashForse;
            rigidbody.DOMove(dashVector, duration);
        }
    }
}
