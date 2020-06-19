﻿
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu"; 


    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Menu() {
        SceneManager.LoadScene(menuSceneName);
    }
}
