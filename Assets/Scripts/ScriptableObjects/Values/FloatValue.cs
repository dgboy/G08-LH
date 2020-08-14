using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Values/Float", fileName = "Float Value")]
public class FloatValue : ScriptableObject {
    public float value;
    #pragma warning restore 0649
    [SerializeField] private float defaultValue;

    private void OnEnable() {
        value = defaultValue;
    }
}
