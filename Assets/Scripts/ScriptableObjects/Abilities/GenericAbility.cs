using UnityEngine;

[CreateAssetMenu(fileName = "Generic Ability", menuName = "ScriptableObjects/Abilities/Generic Ability", order = 0)]
public class GenericAbility : ScriptableObject {
    public float magicCost;
    public float duration;

    public FloatValue playerMagic;
    public GameSignal usePlayerMagic;

    public virtual void Ability(
        Vector2 position, 
        Vector2 facingDirection, 
        Animator animator = null,
        Rigidbody2D rigidbody = null
    ) {
        
    }
    
}
