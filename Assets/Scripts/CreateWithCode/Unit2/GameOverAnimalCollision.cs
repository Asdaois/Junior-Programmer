using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class GameOverAnimalCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Game Over");
        }
    }
}