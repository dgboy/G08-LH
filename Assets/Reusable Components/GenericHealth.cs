using UnityEngine;

public class GenericHealth : MonoBehaviour {
    public FloatValue maxHealth;
    public float currentHealth;


    void Start() {
        currentHealth = maxHealth.runtimeValue;
    }

    public virtual void Heal(float amountToHeal) {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth.runtimeValue) {
            currentHealth = maxHealth.runtimeValue;
        }
    }

    public virtual void FullHeal() {
        currentHealth = maxHealth.runtimeValue;
    }

    public virtual void Damage(float amountToDamage) {
        currentHealth -= amountToDamage;
        if(currentHealth < maxHealth.runtimeValue) {
            currentHealth = 0;
        }
    }

    public virtual void instantDeath() {
        currentHealth = 0;
    }
}
