using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class MoveFordward : MonoBehaviour
    {
        [SerializeField] float speed = 40f;

        void Update()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}