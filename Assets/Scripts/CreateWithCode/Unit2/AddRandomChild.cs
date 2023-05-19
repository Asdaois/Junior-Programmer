using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class AddRandomChild : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs = new();

        private void Start()
        {
            var randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], transform);
        }
    }
}