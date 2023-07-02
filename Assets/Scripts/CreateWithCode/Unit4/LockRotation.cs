using UnityEngine;

namespace CreateWithCode.Unit4
{
    public class LockRotation : MonoBehaviour
    {
        private const float FixedRotation = 0;

        private void Update()
        {
            transform.eulerAngles = new Vector3(FixedRotation, transform.eulerAngles.y, FixedRotation);
        }
    }
}
