using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        [SerializeField] private Bounds limitX = new() { min = -15, max = 15 };
        [SerializeField] private Bounds limitY;

        [SerializeField] private GameObject projectilePrefab;

        [SerializeField] private GameVariables gameVariables;

        private float horizontalInput;
        private float verticalInput;

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            float normalizedSpeed = speed * Time.deltaTime;
            Vector3 direction = new(horizontalInput, transform.position.y, verticalInput);

            transform.Translate(direction.normalized * normalizedSpeed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var go = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                go.GetComponent<DestroyOnCollision>().OnDestroy += OnHitAnimal;
            }
        }

        private void OnHitAnimal()
        {
            gameVariables.IncreaseScore(1);
        }

        private void LateUpdate()
        {
            ClampPositionToBounds();
        }

        private void ClampPositionToBounds()
        {
            transform.position = new Vector3(
                limitX.ClampValue(transform.position.x),
                transform.position.y,
                limitY.ClampValue(transform.position.z)
                );
        }
    }
}