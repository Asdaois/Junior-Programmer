using UnityEngine;

namespace Challenges.Challenge_3.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        public bool gameOver;

        [SerializeField] private float floatForce = 100;
        private const float GravityModifier = 1.5f;
        private Rigidbody _playerRb;

        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;

        private AudioSource _playerAudio;
        [SerializeField] private AudioClip moneySound;
        [SerializeField] private AudioClip explodeSound;
        [SerializeField] private AudioClip boundSound;


        // Start is called before the first frame update
        private void Start()
        {
            Physics.gravity *= GravityModifier;
            _playerAudio = GetComponent<AudioSource>();

            _playerRb = GetComponent<Rigidbody>();

            // Apply a small upward force at the start of the game
            _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        // Update is called once per frame
        private void Update()
        {
            HandleFloat();
        }

        private void HandleFloat()
        {
            const float boundY = 18f;
            if (transform.position.y > boundY) return;
            // While space is pressed and player is low enough, float up
            if (!Input.GetKey(KeyCode.Space) || gameOver) return;

            _playerRb.AddForce(Vector3.up * floatForce);
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                _playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            }

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                _playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                _playerRb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
                _playerAudio.PlayOneShot(boundSound, 1.0f);
            }
        }
    }
}