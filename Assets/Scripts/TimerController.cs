using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int totalTime;
    public Text timerText;
    private int timeLeft;

    void Start()
    {
        StartCountdown();
    }

    private IEnumerator StartCountdown()
    {
        timeLeft = totalTime;
        while (timeLeft > 0)
        {
            UpdateTimeLeft();
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
    }

    private void UpdateTimeLeft()
    {
        timerText.text = timeLeft + " s";
    }

}