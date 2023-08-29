using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCotroller : MonoBehaviour
{
    public string startGame;
    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
