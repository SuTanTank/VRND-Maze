using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private const string DISPLAY_SCORE_FORMAT = "Score: {0, 5} Coins Collected: (1, 3) Time Used: {2:0.0}s\n";
    
    private const float UI_LABEL_START_X = 50.0f;
    private const float UI_LABEL_START_Y = 50.0f;
    private const float UI_LABEL_SIZE_X = 400.0f;
    private const float UI_LABEL_SIZE_Y = 100.0f;

    private GUIStyle guiLabelStyle;
    private Rect guiRectLeft =
      new Rect(UI_LABEL_START_X, UI_LABEL_START_Y, UI_LABEL_SIZE_X, UI_LABEL_SIZE_Y);
#if !UNITY_EDITOR
  private Rect guiRectRight = new Rect(Screen.width / 2 + UI_LABEL_START_X,
      Screen.height - UI_LABEL_START_Y, UI_LABEL_SIZE_X, UI_LABEL_SIZE_Y);
#endif  // !UNITY_EDITOR

    private string scoreText;    

    public Color textColor = Color.white;
    public GameObject playerObject;
    private PlayerScript player;

    void Start()
    {
        player = playerObject.GetComponentInParent<PlayerScript>();        
    }

    void LateUpdate()
    {
        float timeUsed = (Time.time - player.startTime);
        scoreText = string.Format(DISPLAY_SCORE_FORMAT, player.score, player.nCoins, timeUsed);
        if (player.hasKey)
        {
            scoreText += "Key Collected";
        }
    }

    void OnGUI()
    {
        if (guiLabelStyle == null)
        {
            guiLabelStyle = new GUIStyle(GUI.skin.label);
            guiLabelStyle.richText = false;
            guiLabelStyle.fontSize = 14;
        }

        // Draw FPS text.
        GUI.color = textColor;
        GUI.Label(guiRectLeft, scoreText, guiLabelStyle);
#if !UNITY_EDITOR
    GUI.Label(guiRectRight, fpsText, guiLabelStyle);
#endif  // !UNITY_EDITOR
    }
}