using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    private void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        if (verticalInput != 0)
        {
            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime * Vector3.right);
        }
    }
}