using System;
using UnityEngine;
using UnityEngine.Events;

namespace CreateWithCode.Unit4
{
    public class CollisionWithPowerUp : MonoBehaviour
    {
        [SerializeField] private UnityEvent onPickupPowerUp;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Powerup")) return;
            
            onPickupPowerUp.Invoke();
            Destroy(other.gameObject);
        }
    }
}
