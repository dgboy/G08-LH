using UnityEngine;

public class Health : MonoBehaviour {
    [Tooltip("Max and current health \n Set this to one for pots")]
    [Header("Health values")]
    [SerializeField] private int maxHealth;
    private int currentHealth;

    void Start() {
        FullHeal();
    }

    public bool IsAlive => (currentHealth > 0) ? true : false;

    public void IncreaseMaxHealth() => maxHealth += 2;

    public void SetHealth(int amount) => currentHealth = amount;
    public void FullHeal() => currentHealth = maxHealth;
    public void Kill() => currentHealth = 0;

    public void Heal(int amount) {
        currentHealth = (currentHealth > maxHealth) ? maxHealth : currentHealth + amount;
    }
    public virtual void Damage(int amount) {
        currentHealth = (currentHealth <= 0) ? 0 : currentHealth - amount;
    }
}
