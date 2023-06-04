using UnityEngine;

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

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
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
                    break;
                case "Obstacle":
                    Debug.Log("Collide with obstacle");
                    GameOver = true;
                    break;
            }
        }

        private void HandleJump()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || isOnGround == false) return;

            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
}