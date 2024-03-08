using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int points = 1;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.AddScore(points);
    }
}