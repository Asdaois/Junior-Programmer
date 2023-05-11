using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformPositionZ : MonoBehaviour
{
    [SerializeField] bool isNegative;
    [SerializeField] float speed;


    // Update is called once per frame
    void Update()
    {
        int direction = isNegative ? -1 : 1;
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * direction));
    }
}
