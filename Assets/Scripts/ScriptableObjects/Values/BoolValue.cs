using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Bool Value", fileName = "Bool Value")]
[System.Serializable]
public class BoolValue : ScriptableObject {
    public bool runtimeValue;
    public bool defaultValue;

    public void OnAfterDeserialize() {
        runtimeValue = defaultValue;
    }
    
    public void OnBeforeSerialize() {
        
    }

}
