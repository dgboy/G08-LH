using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Values/Vector", fileName = "Vector Value")]
public class VectorValue : ScriptableObject {
    public Vector2 value;
    [SerializeField] private Vector2 defaultValue;

    private void OnEnable() {
        value = defaultValue;
    }
}
