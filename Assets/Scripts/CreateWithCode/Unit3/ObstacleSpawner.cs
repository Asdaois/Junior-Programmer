using UnityEngine;

namespace CreateWithCode.Unit3
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefab;
        
        [SerializeField] private float startDelay = 2;
        [SerializeField] private float repeatDelay = 3;
        
        private PlayerController _playerController;
        [SerializeField] private float leftBound = -30;

        private void Start()
        {
            
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
        }
        private void SpawnObstacle()
        {
            if (_playerController.GameOver == false)
                Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            
            if (transform.position.x < leftBound)
                Destroy(gameObject);
        }
    }
}
