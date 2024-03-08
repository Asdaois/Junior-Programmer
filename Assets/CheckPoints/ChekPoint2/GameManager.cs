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

    [SerializeField] private SphereSpawmer sphereSpawmer;

    private void Start()
    {
        UIManager.ShowMenuScreen();
        sphereSpawmer.enabled = false;
    }

    public void AddScore(int aScore)
    {
        score += aScore;
        UIManager.PresentScore(score);
    }

    public void StartGame(Difficulty aDifficulty)
    {
        Debug.Log($"Current difficulty is: {aDifficulty}");
        UIManager.ShowHUDScreen();
        sphereSpawmer.enabled = true;
    }
}