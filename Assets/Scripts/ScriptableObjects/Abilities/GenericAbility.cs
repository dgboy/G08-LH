using UnityEngine;

[CreateAssetMenu(fileName = "Generic Ability", menuName = "Scriptable Objects/Abilities/Ability", order = 0)]
public class GenericAbility : ScriptableObject {
    public float magicCost;
    public float duration;

    public FloatValue playerMagic;
    public Notification usePlayerMagic;

    public virtual void Ability(
        Vector2 position, 
        Vector2 facingDirection, 
        Animator animator = null,
        Rigidbody2D rigidbody = null
    ) {
        if (playerMagic.value >= magicCost) {
            playerMagic.value -= magicCost;
            usePlayerMagic.Raise();
        }
    }
    
}
