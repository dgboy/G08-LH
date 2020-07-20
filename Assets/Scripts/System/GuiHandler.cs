using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiHandler : MonoBehaviour {
    public GameObject exitAskPanel;

    void Update () {
        if (Input.GetButtonDown("Cancel")) {
            exitAskPanel.SetActive(!exitAskPanel.activeSelf);
        }
    }
}
