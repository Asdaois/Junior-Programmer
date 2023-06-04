using UnityEngine;

namespace Challenges.Challenge_2.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        public GameObject dogPrefab;

        [SerializeField] private float fireRate = 0.8f;

        private float _lastShoot;

        private void Update()
        {
            var canShoot = Time.time - _lastShoot > fireRate;
            // On space bar press, send dog
            if (!Input.GetKeyDown(KeyCode.Space) || !canShoot) return;
            _lastShoot = Time.time;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}