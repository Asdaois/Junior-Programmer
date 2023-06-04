using UnityEngine;

namespace CreateWithCode.Unit1
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void LateUpdate()
        {
            transform.SetPositionAndRotation(target.position, target.rotation);
        }
    }
}