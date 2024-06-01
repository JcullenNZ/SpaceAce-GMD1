using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public static UIManager Instance;
    public GameObject newGameButton;
    public GameObject settingsButton;
    public GameObject quitButton;
    public GameObject volumeSlider;
        public GameObject backButton;
    public GameObject settingsView;
    public GameObject mainMenuView;


    public GameObject highScoreView;



    public GameObject highScore;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        eventSystem = EventSystem.current;
    }
    public void StartGame()
    {
        GameManager.Instance.LoadFirstLevel();
    }

    public void ShowSettings()
    {
        bool isActive = settingsView.activeSelf;
        //highScoreView.SetActive(isActive);
        if(!isActive)
        {
            eventSystem.SetSelectedGameObject(volumeSlider);
        }
        else
        {
            eventSystem.SetSelectedGameObject(newGameButton);
        }
        mainMenuView.SetActive(isActive);
        settingsView.SetActive(!isActive);

    }

    public void QuitGame()
    {
        Debug.Log("Thank's for playing");
        GameManager.Instance.QuitGame();
    }


}
