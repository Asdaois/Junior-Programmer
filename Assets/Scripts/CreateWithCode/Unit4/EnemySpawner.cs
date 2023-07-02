using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CreateWithCode.Unit4
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int spawnRange = 9;
        [SerializeField] private int spawnHeight = 2;
        private int _enemyNumbers = 1;

        private void Start()
        {
            // InvokeRepeating(nameof(SpawnEnemy), 0.5f, 4f);
            SpawnEnemyWave();
        }

        private void Update()
        {
            if (FindObjectsOfType<DestroyOnFallOff>().Length == 0)
            {
                SpawnEnemyWave();
            }
        }

        private void SpawnEnemyWave()
        {
            for (var i = 0; i < _enemyNumbers; i++)
            {
                SpawnEnemy();
            }

            _enemyNumbers++;
        }

        private void SpawnEnemy()
        {
            var spawnPosition = GenerateSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        private Vector3 GenerateSpawnPosition()
        {
            var x = Random.Range(-spawnRange, spawnRange);
            var z = Random.Range(-spawnRange, spawnRange);
            var spawnPosition = new Vector3(x, spawnHeight, z);
            return spawnPosition;
        }
    }
}