using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 20; // meters per second
        [SerializeField] private float turnSpeed = 0;
        [SerializeField] private string inputID;

        private float horizontalInput;
        private float forwardInput;

        private void Update()
        {
            horizontalInput = Input.GetAxis($"Horizontal{inputID}");
            forwardInput = Input.GetAxis($"Vertical{inputID}");

            transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }
}