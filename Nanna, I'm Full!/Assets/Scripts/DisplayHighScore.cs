using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }
}
