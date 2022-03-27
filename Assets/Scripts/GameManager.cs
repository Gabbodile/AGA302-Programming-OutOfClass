using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver,
    InGame
}

public enum Difficulty {Easy, Medium, Hard}
public class GameManager : GameBehaviour<GameManager>
{
    public GameState gameState;
    public Difficulty difficulty;
    int scoreMultiplier = 1;
    int score;

    void Start()
    {
        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        SetUp();
    }

    // Update is called once per frame
    void SetUp()
    {
        switch (difficulty)
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

    public void AddScore(int _points)
    {
        score += _points * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
    }

    void OnEnemyHit(Enemy _enemy)
    {
        AddScore(10);
    }

    public float maxTime = 30;
    float timer = 30;

    void Update()
    {
        if (gameState == GameState.InGame)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, maxTime);
            _UI.UpdateTimer(timer);
        }
    }

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
    }

    public enum Difficulty
    {
        Easy, Medium, Hard
    }
}
