using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;

        private Rigidbody _rigidbody;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.Find("Player");
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var lookupDirection = (_player.transform.position - transform.position).normalized;
            _rigidbody.AddForce(lookupDirection * speed);
        }
    }
}