using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text scoreText;
    public GameObject mainPanel;
    public GameObject pausePanel;
    void Start()
    {
        UpdateScore(0);
    }

    void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
            case GameState.Playing:
                mainPanel.SetActive(true);
                mainPanel.SetActive(false);
                break;
            
            case GameState.Paused:
                mainPanel.SetActive(true);
                mainPanel.SetActive(false);
                break;
            case GameState.Title:
            case GameState.GameOver:
                break;
        }
    }

    private void OnEnable()
    {

        GameEvents.OnScoreChange += UpdateScore;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChange -= UpdateScore;
    }
}
