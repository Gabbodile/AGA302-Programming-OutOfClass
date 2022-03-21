using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver
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
    }
}
