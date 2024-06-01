using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Scene currentScene;
    private bool IsPaused = false;
    private string highScoresFP;

    public enum GameState { MainMenu, InGame, Paused, GameOver };
    public GameState currentState;

    private void Awake()
    {
        //Ensure singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentState = GameState.MainMenu;
    }


    private void Start()
    {
        Debug.Log("Are you being called?");
       // HighScoreManager.Instance.GetHighScores();
        LoadMainMenu();
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        ChangeState(GameState.MainMenu);
       // AudioManager.Instance.PlayMusic("Main Menu");
        Debug.Log("Is music playing?");
    }
    
    public void LoadFirstLevel()
    {
        try{
        SceneManager.LoadScene("Level");
        ChangeState(GameState.InGame);
        //AudioManager.Instance.PlayMusic("Game Music 1");
        }
        catch(System.Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void EndGame(int score, string playerName)
    {
        if (HighScoreManager.Instance.IsHighScore(score))
        {
            HighScoreManager.Instance.AddHighScore(playerName, score);
        }
        ChangeState(GameState.GameOver);
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        if (currentState == GameState.InGame)
        {
            if (IsPaused == false)
            {
                IsPaused = true;
                ChangeState(GameState.Paused);
            }
            else
                IsPaused = false;
            ChangeState(GameState.InGame);
        }
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

}
