using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class GameOverAnimalPass : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Game Over");
        }
    }
}