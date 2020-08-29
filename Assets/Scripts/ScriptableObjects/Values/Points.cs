using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Values/Points", fileName = "Points")]
public class Points : ScriptableObject {
    [SerializeField] private int defaultValue;
    private int maxValue;
    private int value;

    private void OnEnable() {
        value = maxValue = defaultValue;
    }

    public int Max { get => maxValue; set => maxValue = value; }
    public int Current { get => value; }
    public bool IsAlive => (value > 0);

    public void IncreaseMaxHealth(int amount = 2) => value = Max += amount;

    public void FullHeal() => value = Max;
    public void SetHealth(int amount) => value = amount;
    public void Kill() => value = 0;

    public void Heal(int amount) {
        value = (value + amount > Max) ? Max : value + amount;
    }
    public virtual void Damage(int amount) {
        value = (value - amount <= 0) ? 0 : value - amount;
    }
}
