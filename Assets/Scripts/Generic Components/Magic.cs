using UnityEngine;

public class Magic : MonoBehaviour {
    [SerializeField] private FloatValue maxMagic = null;
    private int currentMagic;

    public int Max { get => (int)maxMagic.value; set => maxMagic.value = (int)value; }
    public int Current { get => currentMagic; }
    public bool IsExhausted => (currentMagic <= 0);


    public bool CanUseMagic(int amount) => currentMagic >= amount;

    public void FillMagic() => currentMagic = Max;
    public void SetHealth(int amount) => currentMagic = amount;
    public void UseAllMagic() => currentMagic = 0;


    public virtual void UseMagic(int amount) {
        currentMagic = (currentMagic - amount <= 0) ? 0 : currentMagic - amount;
    }
    public void RestoreMagic(int amount) {
        currentMagic = (currentMagic + amount > Max) ? Max : currentMagic + amount;
    }

    void Start() {
        FillMagic();
    }
}
