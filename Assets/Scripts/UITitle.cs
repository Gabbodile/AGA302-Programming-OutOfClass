using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : GameBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        _GM.ChangeGameState(GameState.InGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
