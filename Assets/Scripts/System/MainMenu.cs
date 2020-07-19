﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void NewGame() {
        SceneManager.LoadScene("World");
    }
    
    public void Exit() {
        Application.Quit();
    }

}
