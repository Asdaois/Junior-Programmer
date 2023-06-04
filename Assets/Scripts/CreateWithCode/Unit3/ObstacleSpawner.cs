using UnityEngine;

namespace CreateWithCode.Unit3
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefab;
        
        [SerializeField] private float startDelay = 2;
        [SerializeField] private float repeatDelay = 3;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
        }
        private void SpawnObstacle()
        {
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
    }
}
