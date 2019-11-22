using UnityEngine;
using UnityEngine.UI;

public class ModeText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameMode gameMode;
    public Text modeText;

    // Update is called once per frame
    void Update()
    {
        modeText.text = gameMode.CurrentMode == Mode.SetUp ? "Play <--" : "Set Up -->";
    }
}
