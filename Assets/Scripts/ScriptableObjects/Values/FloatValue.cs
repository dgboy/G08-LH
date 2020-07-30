using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Values/Float", fileName = "Float Value")]
public class FloatValue : ScriptableObject {
    public float value;
    [SerializeField] private float defaultValue;

    private void OnEnable() {
        value = defaultValue;
    }
}
