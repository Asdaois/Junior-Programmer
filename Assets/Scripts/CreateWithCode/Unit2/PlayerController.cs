using UnityEngine;

namespace CreateWithCode.Unit2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        [SerializeField] private Bounds limitX = new() { min = -15, max = 15 };
        [SerializeField] private Bounds limitY;

        [SerializeField] private GameObject projectilePrefab;

        [SerializeField] private GameVariables gameVariables;

        private float _horizontalInput;
        private float _verticalInput;

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            var normalizedSpeed = speed * Time.deltaTime;
            Vector3 direction = new(_horizontalInput, transform.position.y, _verticalInput);

            transform.Translate(direction.normalized * normalizedSpeed);

            if (!Input.GetKeyDown(KeyCode.Space)) return;
            var go = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            go.GetComponent<DestroyOnCollision>().OnDestroy += OnHitAnimal;
        }

        private void LateUpdate()
        {
            ClampPositionToBounds();
        }

        private void OnHitAnimal()
        {
            gameVariables.IncreaseScore(1);
        }

        private void ClampPositionToBounds()
        {
            var position = transform.position;
            position = new Vector3(
                limitX.ClampValue(position.x),
                position.y,
                limitY.ClampValue(position.z)
            );
            transform.position = position;
        }
    }
}