using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(HandleUI))]
public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        TitleScreen, Playing, GameOver
    }

    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    [SerializeField] private List<GameObject> targets;

    [SerializeField] private UIDocument document;

    private HandleUI handlerUI;
    private float spawnRate = 1;
    private int score = 0;
    private Difficulty _currentDifficulty;
    private GameState _gameState = GameState.TitleScreen;

    public GameState CurrentGameState => _gameState;

    private void Start()
    {
        var rootElement = document.rootVisualElement;
        rootElement.Q<Button>("ButtonRestart").clicked += Restargame;

        handlerUI = GetComponent<HandleUI>();
        handlerUI.TitleScreen();
    }

    private IEnumerator SpawnTarget()
    {
        if (targets.Count < 0)
        {
            throw new System.Exception("You need targets to run the game");
        }

        while (_gameState == GameState.Playing)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            var targetGO = Instantiate(targets[index]);

            targetGO.GetComponent<Target>().gameManager = this;

            UpdateScore(5);
        }
    }

    public void Restargame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int aScoreToAdd)
    {
        score += aScoreToAdd;
        handlerUI.UpdateScore(score);
    }

    internal void GameOver()
    {
        handlerUI.ShowGameOver();
        _gameState = GameState.GameOver;
    }

    public void ChangeDifficulty(Difficulty aDifficulty)
    {
        _currentDifficulty = aDifficulty;
        switch (_currentDifficulty)
        {
            case Difficulty.Easy:
                spawnRate = 1;
                break;

            case Difficulty.Medium:
                spawnRate = 0.75f;
                break;

            case Difficulty.Hard:
                spawnRate = 0.5f;
                break;
        }

        _gameState = GameState.Playing;
        handlerUI.InitGame();
        StartCoroutine(SpawnTarget());
    }
}