using UnityEngine;

namespace CreateWithCode.Unit3
{
    public class RepeatBackground : MonoBehaviour
    {
        private float _repeatWidth;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
            _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        }

        private void Update()
        {
            HandleRestartPosition();
        }

        private void HandleRestartPosition()
        {
            if (!(transform.position.x < _startPosition.x - _repeatWidth)) return;
            transform.position = _startPosition;
        }
    }
}