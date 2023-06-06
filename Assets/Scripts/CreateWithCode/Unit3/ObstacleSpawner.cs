using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CreateWithCode.Unit3
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> obstaclePrefabs;

        [SerializeField] private float startDelay = 2;
        [SerializeField] private float repeatDelay = 3;
        [SerializeField] private float leftBound = -30;

        private PlayerController _playerController;

        private void Start()
        {
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
        }

        private void SpawnObstacle()
        {
            if (_playerController.GameOver == false)
            {
                var randomIndex = Random.Range(0, obstaclePrefabs.Count);
                Instantiate(obstaclePrefabs[randomIndex], transform.position, Quaternion.identity);
            }

            if (transform.position.x < leftBound)
                Destroy(gameObject);
        }
    }
}