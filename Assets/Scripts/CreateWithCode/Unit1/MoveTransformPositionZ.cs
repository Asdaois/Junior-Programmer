using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class MoveTransformPositionZ : MonoBehaviour
    {
        [SerializeField] private bool isNegative;
        [SerializeField] private float speed;

        // Update is called once per frame
        private void Update()
        {
            int direction = isNegative ? -1 : 1;
            transform.Translate(Vector3.forward * (speed * Time.deltaTime * direction));
        }
    }
}