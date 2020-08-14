using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogObject : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI myText = null;

    public void Setup(string newDialog) {
        myText.text = newDialog;
    }
}
