using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}