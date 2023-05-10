using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 20; // meters per second
        [SerializeField] float turnSpeed = 0;

        float horizontalInput;
        float forwardInput;

        void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }
}