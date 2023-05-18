using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float horizontalInput;
        void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }
}