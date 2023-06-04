using System;
using UnityEngine;

namespace CreateWithCode.Unit3
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField] private float speed = 30f;
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (_playerController.GameOver == false)
                transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
