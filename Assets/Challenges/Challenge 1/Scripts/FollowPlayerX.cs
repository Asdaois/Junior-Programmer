using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}