using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class AddRandomChild : MonoBehaviour
    {
        [SerializeField] List<GameObject> prefabs = new();
        void Start()
        {
            var randomIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomIndex], transform);
        }

    }
}