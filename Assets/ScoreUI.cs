using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private const string DISPLAY_SCORE_FORMAT = "Score: {0, 5} Coins: {1, 3} Time Used: {2:0.0}s\n";
    
    private const float UI_LABEL_START_X = 50.0f;
    private const float UI_LABEL_START_Y = 50.0f;
    private const float UI_LABEL_SIZE_X = 400.0f;
    private const float UI_LABEL_SIZE_Y = 100.0f;

    private GUIStyle guiLabelStyle;
    private Rect guiRectLeft =
      new Rect(UI_LABEL_START_X, UI_LABEL_START_Y, UI_LABEL_SIZE_X, UI_LABEL_SIZE_Y);

    private string scoreText;    

    public Color textColor = Color.red;
    public GameObject playerObject;
    private PlayerScript player;

    void Awake()
    {
        player = playerObject.GetComponentInParent<PlayerScript>();
        GetComponent<Text>().color = textColor;
    }

    void LateUpdate()
    {
        float timeUsed = (Time.time - player.startTime);
        scoreText = string.Format(DISPLAY_SCORE_FORMAT, player.score, player.nCoins, player.usedTime);
        if (player.hasKey && !player.finished)
        {
            scoreText += "Key Collected! Get to the door NOW!";
        }
        if (player.hasKey && player.finished)
            scoreText += "Click to restart.";
        GetComponent<Text>().text = scoreText;


    }

}