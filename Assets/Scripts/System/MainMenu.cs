using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public StringValue startSceneName;

    public void NewGame() {
        SceneManager.LoadScene(startSceneName.value);
    }
    
    public void Exit() {
        Application.Quit();
    }

}
