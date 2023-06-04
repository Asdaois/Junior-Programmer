using UnityEngine;

namespace CreateWithCode.Unit1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 20; // meters per second
        [SerializeField] private float turnSpeed;
        [SerializeField] private string inputID;
        private float _forwardInput;

        private float _horizontalInput;

        private void Update()
        {
            _horizontalInput = Input.GetAxis($"Horizontal{inputID}");
            _forwardInput = Input.GetAxis($"Vertical{inputID}");

            transform.Translate(Vector3.forward * (Time.deltaTime * speed * _forwardInput));
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _horizontalInput);
        }
    }
}