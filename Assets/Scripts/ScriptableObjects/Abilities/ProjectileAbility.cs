using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable Objects/Abilities/Projectile")]
public class ProjectileAbility : GenericAbility {
    [SerializeField] private GameObject projectile = null;

    protected override void Ability(
        Vector2 position, Vector2 facingDir,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        // Debug.Log("HERE");
        float facingRot = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        GameObject projectileClone = Instantiate(
            projectile, position, Quaternion.Euler(0f, 0f, facingRot)
        );

        GenericProjectile temp = projectileClone.GetComponent<GenericProjectile>();

        if (temp) {
            temp.Setup(facingDir);
        }
    }
}
