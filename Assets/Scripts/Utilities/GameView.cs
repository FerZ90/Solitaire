using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour, IGameScoreListener
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "Score: 0";
    }

    public void OnScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void GameOver(int score)
    {

    }
}
