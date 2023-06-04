using UnityEngine;

namespace CreateWithCode.Unit2
{
    public class DestroyOnCollision : MonoBehaviour
    {
        public delegate void DestroyEvent();

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            OnDestroy?.Invoke();
        }

        public event DestroyEvent OnDestroy;
    }
}