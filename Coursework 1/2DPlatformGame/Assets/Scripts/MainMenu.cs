using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameObject go;
    private GameStatus gs;

    void Start()
    {
        go = GameObject.Find("GameStatus");
        gs = go.GetComponent<GameStatus>();
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void quitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void startGame()
    {
        gs.restart();
        SceneManager.LoadScene("main");
    }

    public void showControls()
    {
        
    }
}
