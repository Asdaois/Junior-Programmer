using System.Collections;
using UnityEngine;

namespace Challenges.Challenge_4.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smoke;
        private Rigidbody _playerRb;
        private const float Speed = 500;
        private GameObject _focalPoint;

        public bool hasPowerup;
        public GameObject powerupIndicator;
        public int powerUpDuration = 5;

        private const float NormalStrength = 10; // how hard to hit enemy without powerup
        private const float PowerupStrength = 25; // how hard to hit enemy with powerup

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("Focal Point");
        }

        private void Update()
        {
            // Add force to player in direction of the focal point (and camera)
            var verticalInput = Input.GetAxis("Vertical");
            var speed = Speed;
            
            if (Input.GetAxis("Jump") != 0)
            {
                speed *= 1.5f;
                smoke.Play();
            }

            _playerRb.AddForce(_focalPoint.transform.forward * (verticalInput * speed * Time.deltaTime));

            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        }

        // If Player collides with powerup, activate powerup
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Powerup")) return;

            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }

        // Coroutine to count down powerup duration
        private IEnumerator PowerupCooldown()
        {
            yield return new WaitForSeconds(powerUpDuration);
            hasPowerup = false;
            powerupIndicator.SetActive(false);
        }

        // If Player collides with enemy
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;

            var enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * NormalStrength, ForceMode.Impulse);
            }
        }
    }
}