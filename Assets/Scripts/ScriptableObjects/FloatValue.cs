using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Float Value", fileName = "Float Value")]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver {
    public float initialValue;
    
    [HideInInspector]
    public float runtimeValue;

    public void OnAfterDeserialize() {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize() {

    }
}
