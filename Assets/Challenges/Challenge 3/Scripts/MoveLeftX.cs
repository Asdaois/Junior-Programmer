using UnityEngine;

namespace Challenges.Challenge_3.Scripts
{
    public class MoveLeftX : MonoBehaviour
    {
        public float speed;
        private PlayerControllerX _playerControllerScript;
        private const float LeftBound = -10;

        // Start is called before the first frame update
        void Start()
        {
            _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        }

        // Update is called once per frame
        void Update()
        {
            // If game is not over, move to the left
            if (!_playerControllerScript.gameOver)
            {
                transform.Translate(Vector3.left * (speed * Time.deltaTime), Space.World);
            }

            // If object goes off screen that is NOT the background, destroy it
            if (transform.position.x < LeftBound && !gameObject.CompareTag("Background"))
            {
                Destroy(gameObject);
            }

        }
    }
}
