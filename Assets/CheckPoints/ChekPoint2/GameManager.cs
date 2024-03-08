using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    [SerializeField] private UIManager UIManager;
    private int score = 0;

    public int Score { get => score; }

    public void AddScore(int aScore)
    {
        score += aScore;
        UIManager.PresentScore(score);
    }
}