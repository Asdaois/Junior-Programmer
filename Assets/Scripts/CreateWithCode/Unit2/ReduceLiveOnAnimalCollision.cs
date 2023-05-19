using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class ReduceLiveOnAnimalCollision : MonoBehaviour
    {
        public delegate void ChangeLive(int value);

        public event ChangeLive OnReduceLives;

        [SerializeField] private bool destroyOnCollision = true;

        private void OnTriggerEnter(Collider other)
        {
            OnReduceLives?.Invoke(-1);
            if (destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}