using UnityEngine;
using UnityEngine.Serialization;

namespace CreateWithCode.Unit2
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        [SerializeField] private float bound = 30;
        [SerializeField] private Vector2 minimum = new(-30, -30);
        [SerializeField] private Vector2 maximus = new(30, 30);

        private void Update()
        {
            switch (bound)
            {
                case > 0 when transform.position.z > bound:
                case < 0 when transform.position.z < bound:
                    Destroy(gameObject);
                    break;
            }

            var position = transform.position;
            if (position.x > maximus.x
                || position.x < minimum.x
                || position.z > maximus.y
                || position.z < minimum.y)
                Destroy(gameObject);
        }
    }
}