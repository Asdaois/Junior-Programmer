using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace CreateWithCode.Unit3
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 10;

        [SerializeField] private float gravityModifier = 1;

        [SerializeField] private bool isOnGround = true;
        [field: SerializeField] public bool GameOver { get; private set; }

        private Rigidbody _playerRigidbody;

        [FormerlySerializedAs("onPlayerMove")] [SerializeField]
        private UnityEvent onPlayerRun;

        [SerializeField] private UnityEvent onPlayerJump;
        [SerializeField] private UnityEvent onPlayerDeath;

        private bool _isDoubleJumpEnabled;

        private int _score = 0;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
            onPlayerRun.Invoke();

            StartCoroutine(PlayIntro());
        }

        private IEnumerator PlayIntro()
        {
            GameOver = true;           
            var startPosition = transform.position;
            var endPosition = Vector3.zero;

            var journeyLength = Vector3.Distance(startPosition, endPosition);

            var startTime = Time.time;

            var distanceCovered = (Time.time - startTime) * 1f;
            var fractionOfJourney = distanceCovered / journeyLength;

            while (fractionOfJourney < 1)
            {
                distanceCovered = (Time.time - startTime) * 1f;
                fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
                yield return null;
            }

            GameOver = false;
        }

        private void Update()
        {
            // Block every action on game over
            if (GameOver) return;
            HandleJump();

            if (Input.GetKey(KeyCode.D))
            {
                Time.timeScale = 1.5f;

                _score += 2;
            }
            else
            {
                Time.timeScale = 1;
                _score += 1;
            }

            Debug.Log($"Score: {_score}");
        }

        private void OnCollisionEnter(Collision other)
        {
            var colliderTag = other.collider.gameObject.tag;

            Debug.Log(colliderTag);
            switch (colliderTag)
            {
                case "Ground":
                    isOnGround = true;
                    _isDoubleJumpEnabled = true;
                    onPlayerRun.Invoke();
                    break;
                case "Obstacle":
                    Debug.Log("Collide with obstacle");
                    GameOver = true;
                    onPlayerDeath.Invoke();
                    break;
            }
        }

        private void HandleJump()
        {
            // Early Returns jump no posible
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            if (isOnGround == false && _isDoubleJumpEnabled == false)
                return;

            // Jump
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onPlayerJump.Invoke();

            // Is Double Jump?
            if (isOnGround == false)
                _isDoubleJumpEnabled = false;

            // Is definitively not in the ground
            isOnGround = false;
        }
    }
}