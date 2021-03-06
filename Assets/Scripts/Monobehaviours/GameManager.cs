﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI congrats, gameover;
    public void GameOver()

    {
        gameover.SetText("Game Over");
        Invoke("MainMenu", 5f);
    }

    public void Congratulations()
    {
        congrats.SetText("Congratulations!                         You Win!");
        Invoke("MainMenu", 5f);
    }

    void MainMenu()
    {
        FindObjectOfType<AudioManager>().Mute("Theme");
        FindObjectOfType<AudioManager>().UnMute("MainMenu");
        SceneManager.LoadScene("Main Menu");
    }

    void Restart()
    {

    }
}
