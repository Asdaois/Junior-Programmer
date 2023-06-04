using UnityEngine;

namespace CreateWithCode.Unit2
{
    public class MoveFordward : MonoBehaviour
    {
        [SerializeField] private float speed = 40f;

        private void Update()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}