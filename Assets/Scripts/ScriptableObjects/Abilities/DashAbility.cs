using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dash", menuName = "ScriptableObjects/Abilities/Dash", order = 0)]
public class DashAbility : GenericAbility {
    public float dashForse;

    public override void Ability(
        Vector2 position, 
        Vector2 facingDirection, 
        Animator animator = null,
        Rigidbody2D rigidbody = null
    ) {
        if (playerMagic.runtimeValue >= magicCost) {
            playerMagic.runtimeValue -= magicCost;
            usePlayerMagic.Raise();
        } else {
            return;
        }
        if (rigidbody) {
            Vector3 dashVector = rigidbody.transform.position + (Vector3)facingDirection.normalized * dashForse;
            rigidbody.DOMove(dashVector, duration);
        }
    }
}
