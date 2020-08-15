using UnityEngine;

public class Health : MonoBehaviour {
    [Tooltip("Max and current health \n Set this to one for pots")]
    [SerializeField] private FloatValue maxHealth;
    private int currentHealth;

    public int Max { get => (int)maxHealth.value; set => maxHealth.value = (int)value; }
    public int Current { get => currentHealth; }
    public bool IsAlive => (currentHealth > 0);


    public void IncreaseMaxHealth() => currentHealth = Max += 2;
    public void FullHeal() => currentHealth = Max;
    public void SetHealth(int amount) => currentHealth = amount;
    public void Kill() => currentHealth = 0;

    public void Heal(int amount) {
        currentHealth = (currentHealth > Max) ? Max : currentHealth + amount;
    }
    public virtual void Damage(int amount) {
        currentHealth = (currentHealth <= 0) ? 0 : currentHealth - amount;
    }

    void Start() {
        FullHeal();
    }
}
