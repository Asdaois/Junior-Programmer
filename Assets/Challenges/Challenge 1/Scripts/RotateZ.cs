using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);   
    }
}
