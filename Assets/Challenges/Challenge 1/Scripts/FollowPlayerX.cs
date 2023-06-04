using UnityEngine;

namespace Challenges.Challenge_1.Scripts
{
    public class FollowPlayerX : MonoBehaviour
    {
        public GameObject plane;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            transform.position = plane.transform.position + offset;
        }
    }
}