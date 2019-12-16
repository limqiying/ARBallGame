using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
	private int startScore;

    void Start()
	{
		startScore = 0;
        SetCountText();
	}

    public void AddOnePoint()
	{
		startScore++;
        SetCountText();
	}

    public void ResetScore()
    {
        startScore = 0;
        SetCountText();
    }

    public int StartScore()
    {
        return startScore;
    }

    void SetCountText()
    {
        scoreText.text = startScore.ToString();
    }

}
