using System;
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

        [FormerlySerializedAs("onPlayerMove")] [SerializeField] private UnityEvent onPlayerRun;
        [SerializeField] private UnityEvent onPlayerJump;
        [SerializeField] private UnityEvent onPlayerDeath;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
            onPlayerRun.Invoke();
        }

        private void Update()
        {
            // Block every action on game over
            if (GameOver) return;
            HandleJump();
        }

        private void OnCollisionEnter(Collision other)
        {
            var colliderTag = other.collider.gameObject.tag;

            Debug.Log(colliderTag);
            switch (colliderTag)
            {
                case "Ground":
                    isOnGround = true;
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
            if (!Input.GetKeyDown(KeyCode.Space) || isOnGround == false) return;

            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            onPlayerJump.Invoke();
        }
    }
}