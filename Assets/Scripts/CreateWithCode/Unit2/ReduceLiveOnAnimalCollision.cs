using UnityEngine;

namespace CreateWithCode.Unit2
{
    public class ReduceLiveOnAnimalCollision : MonoBehaviour
    {
        public delegate void ChangeLive(int value);

        [SerializeField] private bool destroyOnCollision = true;

        private void OnTriggerEnter(Collider other)
        {
            OnReduceLives?.Invoke(-1);
            if (destroyOnCollision) Destroy(gameObject);
        }

        public event ChangeLive OnReduceLives;
    }
}