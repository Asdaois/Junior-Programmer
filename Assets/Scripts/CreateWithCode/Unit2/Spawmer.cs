using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public partial class Spawmer : MonoBehaviour
    {
        [SerializeField] private Bounds boundX;
        [SerializeField] private Bounds boundY;

        [SerializeField] private List<GameObject> prefabs = new();

        [SerializeField] private float startDelay = 2f;
        [SerializeField] private float spawnInterval = 2f;

        [SerializeField] private Vector3 rotation = new(0, 180, 0);
        [SerializeField] private bool addAgressiveBehaviour = false;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnAnimal), startDelay, spawnInterval);
        }

        private void SpawnAnimal()
        {
            var randomPosition = new Vector3(
                Random.Range(boundX.min, boundX.max),
                0,
                Random.Range(boundY.min, boundY.max)
                );
            var randomAnimal = prefabs[Random.Range(0, prefabs.Count)];

            var go = Instantiate(randomAnimal, randomPosition, Quaternion.Euler(rotation));

            if (addAgressiveBehaviour)
            {
                go.AddComponent<GameOverAnimalCollision>();
                var gorb = go.AddComponent<Rigidbody>();
                gorb.useGravity = false;
            }
        }
    }
}