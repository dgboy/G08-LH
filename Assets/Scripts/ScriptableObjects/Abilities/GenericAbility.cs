using UnityEngine;

public abstract class GenericAbility : ScriptableObject {
    public int magicCost;
    public float duration;

    public void Use(
        Magic magic, Vector2 position, Vector2 facingDir,
        Animator animator = null, Rigidbody2D rigidbody = null
    ) {
        // Debug.Log(magic.IsExhausted);
        if (!magic.IsExhausted) {
            magic.UseMagic(magicCost);
            Ability(position, facingDir, animator, rigidbody);
        }
    }

    protected abstract void Ability(
        Vector2 position, Vector2 facingDir,
        Animator animator = null, Rigidbody2D rigidbody = null
    );
}
