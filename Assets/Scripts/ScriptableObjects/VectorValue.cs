﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Vector Value", fileName = "Vector Value")]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver {
    public Vector2 initialValue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize() {
        initialValue = defaultValue;
    }
    
    public void OnBeforeSerialize() {
        
    }

}
