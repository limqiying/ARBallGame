using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int totalTime;
    public Text timerText;
    public GameMode gameMode;

    public int timeLeft;
    private bool gameStarted;

    void Start()
    {
        gameStarted = false;
        timeLeft = totalTime;
        UpdateTimeLeft();
    }

    private void Update()
    {
        if (!gameStarted && gameMode.CurrentMode == Mode.Playing)
        {
            StartCoroutine(StartCountdown());
            gameStarted = true;
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
