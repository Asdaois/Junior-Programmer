using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float bound = 30;

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
    }
}