using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateTimer(float _timer)
    {
        timerText.text = "Time Remaining: " + _timer.ToString("F2");
        timerText.color = _timer < 10f ? Color.red : Color.white;
    }
}
