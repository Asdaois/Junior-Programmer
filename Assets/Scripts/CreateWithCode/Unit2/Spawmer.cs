using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class Spawmer : MonoBehaviour
    {
        [Serializable]
        public struct SpawmerBounds
        {
            public float min;
            public float max;
        }

        [SerializeField] private SpawmerBounds boundX;
        [SerializeField] private SpawmerBounds boundY;

        [SerializeField] private List<GameObject> prefabs = new();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                var randomPosition = new Vector3(
                    UnityEngine.Random.Range(boundX.min, boundX.max),
                    0,
                    UnityEngine.Random.Range(boundY.min, boundY.max)
                    );
                var randomAnimal = prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
                Instantiate(randomAnimal, randomPosition, randomAnimal.transform.rotation);
            }
        }
    }
}