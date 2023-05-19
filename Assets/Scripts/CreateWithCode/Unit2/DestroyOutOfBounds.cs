using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float bound = 30;
    [SerializeField] private Vector2 minimus = new(-30, -30);
    [SerializeField] private Vector2 maximus = new(30, 30);

    private void Update()
    {
        if (bound > 0 && transform.position.z > bound)
        {
            Destroy(gameObject);
        }

        if (bound < 0 && transform.position.z < bound)
        {
            Destroy(gameObject);
        }

        var position = transform.position;
        if (position.x > maximus.x
            || position.x < minimus.x
            || position.z > maximus.y
            || position.z < minimus.y)
        {
            Destroy(gameObject);
        }
    }
}