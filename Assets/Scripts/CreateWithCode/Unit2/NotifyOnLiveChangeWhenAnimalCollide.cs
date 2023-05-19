using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    [RequireComponent(typeof(ReduceLiveOnAnimalCollision))]
    public class NotifyOnLiveChangeWhenAnimalCollide : MonoBehaviour
    {
        [SerializeField] private GameVariables gameVariables;

        private void Start()
        {
            GetComponent<ReduceLiveOnAnimalCollision>().OnReduceLives += gameVariables.IncreaseLive;
        }
    }
}