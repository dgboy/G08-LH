using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public string mainMenu;

    private bool isPaused;

    void Start() {
        isPaused = false;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if(!pausePanel.activeSelf && inventoryPanel.activeSelf) {
                ChangePanelActive(inventoryPanel);
            } else {
                ChangePanelActive(pausePanel);
            }
        }
        if (Input.GetButtonDown("Inventory") && !pausePanel.activeSelf) {
            ChangePanelActive(inventoryPanel);
        }
    }

    // Buttons
    public void Resume() {
        ChangePanelActive(pausePanel);
    }
    public void QuitToMain() {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }


    private void ChangePanelActive(GameObject panel) {
        panel.SetActive(!panel.activeSelf);
        Time.timeScale = (panel.activeSelf) ? 0f : 1f;
    }
}
