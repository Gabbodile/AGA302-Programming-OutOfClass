using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, Playing, Paused, GameOver};
public enum Difficulty { Easy, Medium, Hard};
public class GameManager : GameBehaviour<GameManager>
{

    public GameState gameState;
    public Difficulty diffculty;
    public int score;
    int scoreMultiplier = 1;
    bool isPaused = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //gameState = GameState.Title;

        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        //if (gameState != GameState.Playing || gameState != GameState.Paused)
        //    return;

        isPaused = !isPaused;
        if (isPaused)
        {
            ChangeGameState(GameState.Paused);
            Time.timeScale = 0;
        }
        else
        {
            ChangeGameState(GameState.Playing);
            Time.timeScale = 1;
        }
    }

    public void AddScore(int _value)
    {
        score += _value * scoreMultiplier;
        GameEvents.ReportScoreChange(score);
    }

    void OnEnemyHit(Enemy _enemy)
    {
        AddScore(10);
    }

    void OnEnemyDied(Enemy _enemy)
    {
        AddScore(100);
    }

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
        GameEvents.ReportGameStateChange(gameState);
    }

    public void ChangeDifficulty(int _difficulty)
    {
        diffculty = (Difficulty)_difficulty;

        switch (diffculty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
            default:
                scoreMultiplier = 1;
                break;

        }
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
        GameEvents.OnEnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
        GameEvents.OnEnemyDied -= OnEnemyDied;
    }
}
