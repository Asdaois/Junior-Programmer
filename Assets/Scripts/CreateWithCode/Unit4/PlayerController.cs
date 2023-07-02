using System;
using System.Collections;
using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject focalPoint;
        [SerializeField] private float speed = 5f;
        [SerializeField] private GameObject powerupIndicator;

        private Rigidbody _rigidbody;
        private bool _hasPowerUp;
        private const int PowerUpTimer = 7;
        private const float PowerUpStrength = 15;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (focalPoint == null)
            {
                Debug.LogError("PlayerController: You have to specific the focal point");
            }
        }

        private void Update()
        {
            var verticalInput = Input.GetAxis("Vertical");

            _rigidbody.AddForce(focalPoint.transform.forward * (verticalInput * speed));
        }

        public void ActivatePowerUp()
        {
            _hasPowerUp = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(DesactivePowerUp());
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy") && _hasPowerUp)
            {
                HandleCollisionWithEnemy(other);
            }
        }

        private void HandleCollisionWithEnemy(Collision other)
        {
            var directionFromPlayer = other.gameObject.transform.position - transform.position;

            var enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            enemyRigidBody.AddForce(directionFromPlayer * PowerUpStrength, ForceMode.Impulse);
            Debug.Log($"Collide with {other.gameObject.name} with powerUp set to {_hasPowerUp}");
        }

        private IEnumerator DesactivePowerUp()
        {
            yield return new WaitForSeconds(PowerUpTimer);
            _hasPowerUp = false;
            powerupIndicator.SetActive(true);
            
            Debug.Log("PowerUp off");
        }
    }
}