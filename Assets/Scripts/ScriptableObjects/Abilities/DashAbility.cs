using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dash", menuName = "Scriptable Objects/Abilities/Dash", order = 0)]
public class DashAbility : GenericAbility {
    public float dashForse;

    protected override void Ability(
        Vector2 position, Vector2 facingDir,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        if (rigidbody) {
            Vector3 temp = (Vector3)facingDir.normalized * dashForse;
            Vector3 dashVector = rigidbody.transform.position + temp;
            rigidbody.DOMove(dashVector, duration);
        }
    }
}
