using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour {
    public void ExitTheGame() {
        Debug.Log("Exit!");
        Application.Quit();
    }
    public void CloseExitWindow(GameObject panel) {
        Debug.Log("close!");
        panel.SetActive(false);
    }
}
