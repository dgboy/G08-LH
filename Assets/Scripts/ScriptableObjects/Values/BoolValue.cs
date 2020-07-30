using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Values/Bool", fileName = "Bool Value")]
[System.Serializable]
public class BoolValue : ScriptableObject {
    public bool value;
    [SerializeField] private bool defaultValue;

    private void OnEnable() {
        value = defaultValue;
    }

}