using System;
using UnityEngine;

namespace CreateWithCode.Unit3
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private float gravityModifier = 1;

        [SerializeField] private bool isOnGround = true;

        private Rigidbody _playerRigidbody;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
            HandleJump();
        }

        private void HandleJump()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || isOnGround == false)
            {
                return;
            }

            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            isOnGround = true;
        }
    }
}