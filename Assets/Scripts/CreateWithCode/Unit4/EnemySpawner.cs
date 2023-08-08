using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CreateWithCode.Unit4
{
    [Serializable]
    internal struct CustomRange
    {
        public int min;
        public int max;
    }
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject superEnemyPrefab;
        [SerializeField] private int spawnRange = 9;
        [SerializeField] private int spawnHeight = 2;
        [SerializeField] private CustomRange spawnSuperEnemyRange;
        private int _enemyNumbers = 1;

        private void Start()
        {
            // InvokeRepeating(nameof(SpawnEnemy), 0.5f, 4f);
            SpawnEnemyWave();
            
            var randomSpawnTime = Random.Range(spawnSuperEnemyRange.min, spawnSuperEnemyRange.max);
            Invoke(nameof(SpawnSuperEnemy), randomSpawnTime);
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
        
        private void SpawnSuperEnemy() {
            var randomSpawnTime = Random.Range(spawnSuperEnemyRange.min, spawnSuperEnemyRange.max);
            var spawnPosition = GenerateSpawnPosition();
            Instantiate(superEnemyPrefab, spawnPosition, Quaternion.identity);
            Invoke(nameof(SpawnSuperEnemy), randomSpawnTime);
        }
    }
}