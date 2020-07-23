using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    public GameObject pausePanel;
    public string mainMenu;
    private bool isPaused;

    void Start() {
        isPaused = false;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            ChangePause();
        }
    }

    // Buttons
    public void Resume() {
        ChangePause();
    }

    public void QuitToMain() {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    void ChangePause() {
        isPaused = !isPaused;
        if (isPaused) {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        } else {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
