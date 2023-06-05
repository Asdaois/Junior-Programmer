using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Camera _camera;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _camera = Camera.main;
        }

        private void Update()
        {
            // Right Click
            if (Input.GetMouseButton(1))
            {
                MoveToClickedPosition();
            }
        }

        private void MoveToClickedPosition()
        {
            if (Input.GetMouseButtonDown(1))
                _agent.velocity = Vector3.zero;
            
            var ray = _camera!.ScreenPointToRay(Input.mousePosition);
            var isHit = Physics.Raycast(ray, out var hit);
            if (isHit)
            {
                _agent.destination = hit.point;
            }
        }
    }
}