using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private SphereSpawmer sphereSpawmer;
    [SerializeField] private UIManager UIManager;

    [SerializeField] private int originalGameTime = 0;
    private int gameTime = 0;
    private Timer gameTimer;

    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    private Difficulty difficulty;

    public int Score { get => score; }

    public void AddScore(int aScore)
    {
        score += aScore;
        UIManager.PresentScore(score);

        switch (difficulty)
        {
            case Difficulty.Easy:
                break;

            case Difficulty.Medium:
                score += 1;
                break;

            case Difficulty.Hard:
                score += 2;
                break;
        }
    }

    public void StartGame(Difficulty aDifficulty)
    {
        difficulty = aDifficulty;
        var spheres = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (var sphere in spheres)
        {
            Destroy(sphere);
        }
        UIManager.ShowHUDScreen();
        sphereSpawmer.enabled = true;
        gameTime = originalGameTime;
        score = 0;

        if (Random.value >= 0.5f)
        {
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
        }

        gameTimer.IsActive = true;
        UIManager.PresentTime(gameTime);
        UIManager.PresentScore(score);
    }

    private void Start()
    {
        UIManager.ShowMenuScreen();
        sphereSpawmer.enabled = false;
        gameTimer = GetComponent<Timer>();
    }

    public void OnTime()
    {
        gameTime--;
        UIManager.PresentTime(gameTime);

        if (gameTime <= 0)
        {
            sphereSpawmer.enabled = false;
            UIManager.ShowMenuScreen();
            gameTimer.IsActive = false;
        }
    }
}