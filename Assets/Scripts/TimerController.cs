using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int totalTime;
    public Text timerText;
    public GameMode gameMode;

    private int timeLeft;
    private bool gameStarted;

    void Start()
    {
        gameStarted = false;
        timeLeft = totalTime;
        UpdateTimeLeft();
    }

    public void SetTimeLeft(int value)
    {
        timeLeft = value;
        UpdateTimeLeft();
        gameStarted = false;
    }

    private void Update()
    {
        if (!gameStarted && gameMode.CurrentMode == Mode.Playing)
        {
            StartCoroutine(StartCountdown());
            gameStarted = true;
        }

        if (gameStarted && timeLeft < 5.0f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }

        if (gameStarted && timeLeft == 0)
        {
            UpdateTimeLeft();
            gameMode.GameOver();
            gameStarted = false;
        }
    }

    private IEnumerator StartCountdown()
    {
        while (timeLeft > 0)
        {
            UpdateTimeLeft();
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
    }

    private void UpdateTimeLeft()
    {
        timerText.text = timeLeft + "s";
    }

}
