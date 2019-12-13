using UnityEngine;
using UnityEngine.UI;

public class GameOverTextController : MonoBehaviour
{
    public Text gameOverText;
    public GameMode gameMode;
    public ScoreKeeper score;

    public Button replayButton;

    void Start()
    {
        Hide();
    }

    void Update()
    {
        if (gameMode.CurrentMode == Mode.GameOver)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        gameOverText.text = "Game Over! \n" + score.startScore + " point" + (score.startScore > 1 ? "s" : "");
        replayButton.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameOverText.text = "";
        replayButton.gameObject.SetActive(false);
    }
}