using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Multi Projectile", menuName = "Scriptable Objects/Abilities/Multi Projectile")]
public class MultiProjectileAbility : GenericAbility {
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private int count = 3;
    [SerializeField] private float spread = 80;

    protected override void Ability(
        Vector2 position, Vector2 facingDir,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        Debug.Log(facingDir);
        float facingRotation = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        Debug.Log(facingRotation);
        float startRotation = facingRotation + spread / 2f;
        float angleIncrease = spread / ((float)count - 1f);

        for (int i = 0; i < count; i++) {
            float tempRot = startRotation - angleIncrease * i;
            GameObject projectileClone = Instantiate(
                projectile, position, Quaternion.Euler(0f, 0f, tempRot)
            );
            GenericProjectile temp = projectileClone.GetComponent<GenericProjectile>();

            if (temp) {
                temp.Setup(new Vector2(
                    Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad))
                );
            }
        }
    }

}
