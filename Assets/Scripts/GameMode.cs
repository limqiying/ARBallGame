using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Mode CurrentMode { get; set; }
    public ScoreKeeper scoreKeeper;
    public GameObject timerText;

    private TimerController timerController;

    void Start()
	{
        SetUp();
        timerController = timerText.GetComponent<TimerController>();
	}

    public void RestartGame()
    {
        Playing();
        scoreKeeper.ResetScore();
        timerController.SetTimeLeft(timerController.totalTime);
    }

    public void SetUp()
    {
        CurrentMode = Mode.SetUp;
    }

    public void Playing()
    {
        CurrentMode = Mode.Playing;
    }

    public void GameOver()
    {
        CurrentMode = Mode.GameOver;
    }
}
