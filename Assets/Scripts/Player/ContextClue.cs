using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour {
    [SerializeField] private SpriteRenderer mySprite = null;

    public void ChangeClue() {
        mySprite.enabled = !mySprite.enabled;
    }
}
