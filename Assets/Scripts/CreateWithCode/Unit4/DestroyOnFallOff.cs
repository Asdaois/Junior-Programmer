using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class DestroyOnFallOff : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -10)
            {
                Destroy(gameObject);
            }
        }
    }
}
