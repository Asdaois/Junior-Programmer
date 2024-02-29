using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(HandleUI))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private UIDocument document;

    private HandleUI handlerUI;
    private readonly float spawnRate = 1;
    private int score = 0;
    private bool isGameActive = false;

    public bool IsGameActive { get => isGameActive; }

    private void Start()
    {
        var rootElement = document.rootVisualElement;
        rootElement.Q<Button>("ButtonRestart").clicked += Restargame;
        isGameActive = true;

        handlerUI = GetComponent<HandleUI>();
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        if (targets.Count < 0)
        {
            throw new System.Exception("You need targets to run the game");
        }

        while (isGameActive)
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
        isGameActive = false;
    }
}