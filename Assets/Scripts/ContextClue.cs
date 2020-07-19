using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour {
    public GameObject contextClue;
    public bool clueActive = false;

    public void ChangeClue() {
        contextClue.SetActive(clueActive = !clueActive);
    }
}
