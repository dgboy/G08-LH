using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Max and current health \n Set this to one for pots")]
    [Header("Health values")]
    [SerializeField] private int maxHealth;
    [SerializeField] public int currentHealth;

    public void SetHealth(int amount) {
        currentHealth = amount;
    }

    public void Heal(int amount) {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void FullHeal() {
        currentHealth = maxHealth;
    }

    public virtual void Damage(int damage) {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void Kill() {
        currentHealth = 0;
    }
}
