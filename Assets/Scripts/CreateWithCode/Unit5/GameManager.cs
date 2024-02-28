using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandleScoreUI))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    private HandleScoreUI scoreHandler;
    private readonly float spawnRate = 1;
    private int score = 0;

    private void Start()
    {
        scoreHandler = GetComponent<HandleScoreUI>();
        scoreHandler.UpdateScore(5);
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        if (targets.Count < 0)
        {
            throw new System.Exception("You need targets to run the game");
        }

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            var targetGO = Instantiate(targets[index]);

            targetGO.GetComponent<Target>().gameManager = this;

            UpdateScore(5);
        }
    }

    public void UpdateScore(int aScoreToAdd)
    {
        score += aScoreToAdd;
        scoreHandler.UpdateScore(score);
    }
}