using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;

    private void Update()
    {
        var otherPosition = objectToFollow.transform.position;
        transform.position = new Vector3(otherPosition.x, transform.position.y, otherPosition.z - 5);
    }
}