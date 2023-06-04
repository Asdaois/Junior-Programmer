using UnityEngine;

namespace Challenges.Challenge_2.Scripts
{
    public class DestroyOutOfBoundsX : MonoBehaviour
    {
        private const float BottomLimit = -5;
        private const float LeftLimit = -30;

        // Update is called once per frame
        private void Update()
        {
            // Destroy dogs if x position less than left limit
            if (transform.position.x < LeftLimit)
                Destroy(gameObject);
            // Destroy balls if y position is less than bottomLimit
            else if (transform.position.y < BottomLimit) Destroy(gameObject);
        }
    }
}