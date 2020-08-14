using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable Objects/Abilities/Projectile")]
public class ProjectileAbility : GenericAbility {
    [SerializeField] private GameObject projectile = null;

    public override void Ability(
        Vector2 position, Vector2 facingDirection,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        base.Ability(position, facingDirection, animator, rigidbody);
        if (playerMagic.value <= magicCost) {
            return;
        }

        float facingRotation = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        GameObject projectileClone = Instantiate(
            projectile, position, Quaternion.Euler(0f, 0f, facingRotation)
        );

        GenericProjectile temp = projectileClone.GetComponent<GenericProjectile>();

        if (temp) {
            temp.Setup(facingDirection);
        }
    }
}
