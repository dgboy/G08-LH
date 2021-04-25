using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TODO: requred TextMeshProUGUI
public class LocalizedText : MonoBehaviour {
    public string key;

    void Start() {
        TextMeshProUGUI tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = LocalizationManager.instance.GetLocalizedValue(key);
    }
}
