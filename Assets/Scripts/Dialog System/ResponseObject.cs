﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseObject : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI myText = null;
    private int choiceValue;

    public void Setup(string newDialog, int myChoice) {
        myText.text = newDialog;
        choiceValue = myChoice;
    }
}
