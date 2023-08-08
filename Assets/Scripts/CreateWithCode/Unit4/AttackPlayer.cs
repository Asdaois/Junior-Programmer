using UnityEngine;
using UnityEngine.Serialization;

namespace CreateWithCode.Unit4
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private bool tackle;
        private Rigidbody _rigidbody;
        private GameObject _player;
        private Vector3 _lookupDirection;

        private void Start()
        {
            _player = GameObject.Find("Player");
            _rigidbody = GetComponent<Rigidbody>();

            LookPlayer();
        }

        private void LookPlayer()
        {
            _lookupDirection = (_player.transform.position - transform.position).normalized;
        }

        private void Update()
        {
            if (!tackle)
            {
                LookPlayer();
            }

            _rigidbody.AddForce(_lookupDirection * speed);
        }
    }
}