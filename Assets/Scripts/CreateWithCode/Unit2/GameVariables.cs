using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    [Serializable]
    public class ChangeValue : UnityEvent<int>
    { }

    public class GameVariables : MonoBehaviour
    {
        [SerializeField] private int lives = 3;
        [SerializeField] private int score;

        private void Start()
        {
            Debug.Log($"Lives: {lives}");
            Debug.Log($"Score: {score}");
        }

        public void IncreaseLive(int value)
        {
            lives += value;
            Debug.Log($"Lives: {lives}");
        }

        public void IncreaseScore(int value)
        {
            score += value;
            Debug.Log($"Score: {score}");
        }
    }
}