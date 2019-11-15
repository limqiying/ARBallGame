using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
	public int startScore;
    public Text scoreText;

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

    void SetCountText()
    {
        scoreText.text = startScore.ToString();
    }
}
