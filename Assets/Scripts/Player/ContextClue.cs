using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class ContextClue : MonoBehaviour {
    private SpriteRenderer mySprite;

    void Start() {
        mySprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeClue() {
        mySprite.enabled = !mySprite.enabled;
    }
}
