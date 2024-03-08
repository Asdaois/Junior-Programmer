using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text CounterText;

    public int Score { get => score; }

    public void AddScore(int aScore)
    {
        score += aScore;
        CounterText.text = $"Score: {score}";
    }
}