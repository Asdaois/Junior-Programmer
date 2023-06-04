using UnityEngine;

namespace Challenges.Challenge_2.Scripts
{
    public class SpawnManagerX : MonoBehaviour
    {
        public GameObject[] ballPrefabs;
        private const float MaxSpawnInterval = 5f;
        private const float MinSpawnInterval = 3f;

        private const float SpawnLimitXLeft = -22;
        private const float SpawnLimitXRight = 7;
        private const float SpawnPosY = 30;

        private const float StartDelay = 1.0f;

        // Start is called before the first frame update
        private void Start()
        {
            Invoke(nameof(SpawnRandomBall), StartDelay);
        }

        // Spawn random ball at random x position at top of play area
        private void SpawnRandomBall()
        {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new(Random.Range(SpawnLimitXLeft, SpawnLimitXRight), SpawnPosY, 0);
            var randomIndex = Random.Range(0, ballPrefabs.Length);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);

            var randomTime = Random.Range(MinSpawnInterval, MaxSpawnInterval);
            Invoke(nameof(SpawnRandomBall), randomTime);
        }
    }
}