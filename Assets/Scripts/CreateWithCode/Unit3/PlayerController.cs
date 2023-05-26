using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit3
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private float gravityModifier = 1;

        private Rigidbody playerRigidbody;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        private void Update()
        {
            HandleJump();
        }

        private void HandleJump()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}