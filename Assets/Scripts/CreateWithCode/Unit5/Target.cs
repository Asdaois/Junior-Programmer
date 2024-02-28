using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 16;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float spawnPositionX = 4;
    [SerializeField] private float spawnPositionY = -6;

    private Rigidbody _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.AddForce(GenerateRandomForce(), ForceMode.Impulse);
        _rb.AddTorque(GenerateRandomTorque(), GenerateRandomTorque(), GenerateRandomTorque(), ForceMode.Impulse);

        transform.position = GenerateRandomPosition();
    }

    private Vector3 GenerateRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float GenerateRandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 GenerateRandomPosition()
    {
        return new Vector3(
            Random.Range(-spawnPositionX, spawnPositionX),
            spawnPositionY
        );
    }
}