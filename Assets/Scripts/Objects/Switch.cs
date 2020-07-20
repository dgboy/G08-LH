using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    public SpriteRenderer mySprite;
    public LockedDoor thisDoor;

    void Start() {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.runtimeValue;
        if(active) {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch() {
            active = true;
            storedValue.runtimeValue = active;
            mySprite.sprite = activeSprite;
            thisDoor.Open();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            ActivateSwitch();
        }
    }
}
