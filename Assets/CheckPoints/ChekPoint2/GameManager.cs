using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private SphereSpawmer sphereSpawmer;
    [SerializeField] private UIManager UIManager;

    private int gameTime = 0;
    private Timer gameTimer;

    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    public int Score { get => score; }

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
        gameTime = 60;

        switch (aDifficulty)
        {
            case Difficulty.Easy:
                sphereSpawmer.SpeedFactor = 0.5f;
                break;

            case Difficulty.Medium:
                sphereSpawmer.SpeedFactor = 1f;
                break;

            case Difficulty.Hard:
                sphereSpawmer.SpeedFactor = 2f;
                break;
        }

        gameTimer.IsActive = true;
    }

    private void Start()
    {
        UIManager.ShowMenuScreen();
        sphereSpawmer.enabled = false;
        gameTimer = GetComponent<Timer>();
    }

    public void OnTime()
    {
        Debug.Log(gameTime);
        gameTime--;
        UIManager.PresentTime(gameTime);

        if (gameTime <= 0)
        {
            sphereSpawmer.enabled = false;
            UIManager.ShowMenuScreen();
        }
    }
}