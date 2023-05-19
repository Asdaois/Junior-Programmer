using UnityEngine;

public class RotateZ : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}