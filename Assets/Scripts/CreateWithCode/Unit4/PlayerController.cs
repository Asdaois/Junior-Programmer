using System;
using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject focalPoint;
        [SerializeField] private float speed = 5f;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (focalPoint == null)
            {
                Debug.LogError("PlayerController: You have to specific the focal point");
            }
        }

        private void Update()
        {
            var verticalInput = Input.GetAxis("Vertical");


            _rigidbody.AddForce(focalPoint.transform.forward * (verticalInput * speed));
        }
    }
}