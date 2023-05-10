using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 20; // meters per second

        void Start()
        {

        }

        void Update()
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }
    }
}