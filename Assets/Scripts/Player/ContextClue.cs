﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite;
    // [SerializeField] private bool clueActive = false;

    public void ChangeClue() {
        mySprite.enabled = !mySprite.enabled;
        // contextClue.SetActive(clueActive = !clueActive);
    }
}
