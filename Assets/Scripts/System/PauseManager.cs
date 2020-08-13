using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    public string mainMenu;
    public GameObject pausePanel;
    public GameObject inventoryPanel;

    public void CancelPause() {
        if(!pausePanel.activeSelf && inventoryPanel.activeSelf) {
            ChangePanelActive(inventoryPanel);
        } else {
            ChangePanelActive(pausePanel);
        }
    }

    public void DisplayInventory() {
        if (!pausePanel.activeSelf) {
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
