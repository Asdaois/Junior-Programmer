using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class RotateWithInput : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;
        private void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * rotationSpeed);
        }
    }
}
