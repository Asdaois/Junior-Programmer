using UnityEngine;

namespace CreateWithCode.Unit3
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField] private float speed = 30f;
        
        private void Update()
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
