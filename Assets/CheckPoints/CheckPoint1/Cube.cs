using UnityEngine;

namespace CheckPoints.CheckPoint1
{
    public class Cube : MonoBehaviour
    {
        public MeshRenderer Renderer;

        [SerializeField] private Vector3 targetPosition = new(4, 4, 4);

        [SerializeField] private Vector3 speed = new(0.2f, 0.4f, 0.1f);

        [SerializeField] private Vector3 targetScale = Vector3.one;

        [SerializeField] private float updateScaleTime = 2f;

        private void Start()
        {
            transform.localScale = Vector3.one * 1.3f;

            var material = Renderer.material;
            material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

            InvokeRepeating(nameof(RandomizeScale), updateScaleTime, updateScaleTime);
        }

        private void Update()
        {
            var material = Renderer.material;
            material.color = new Color(
                0.5f * Mathf.Sin(Time.time + 12f),
                1.0f * Mathf.Sin(Time.time + 42f),
                0.3f * Mathf.Sin(Time.time + 35f),
                0.4f * Mathf.Sin(Time.time + 62f));

            var position = transform.position;
            position = new Vector3(
                Mathf.Lerp(position.x, targetPosition.x, Time.deltaTime * speed.x),
                Mathf.Lerp(position.y, targetPosition.y, Time.deltaTime * speed.y),
                Mathf.Lerp(position.z, targetPosition.z, Time.deltaTime * speed.z)
            );
            transform.position = position;

            transform.Rotate(10.0f * Time.deltaTime, 0.2f * Time.deltaTime, 2.0f * Time.deltaTime);

            if (Mathf.Abs(transform.position.x) > Mathf.Abs(targetPosition.x) - 0.1) targetPosition.x *= -1;
            if (Mathf.Abs(transform.position.y) > Mathf.Abs(targetPosition.y) - 0.1) targetPosition.y *= -1;
            if (Mathf.Abs(transform.position.z) > Mathf.Abs(targetPosition.z) - 0.1) targetPosition.z *= -1;

            var localScale = transform.localScale;
            localScale = new Vector3(
                Mathf.Lerp(localScale.x, targetScale.x, Time.deltaTime * updateScaleTime),
                Mathf.Lerp(localScale.y, targetScale.x, Time.deltaTime * updateScaleTime),
                Mathf.Lerp(localScale.z, targetScale.x, Time.deltaTime * updateScaleTime));
            transform.localScale = localScale;
        }

        private void RandomizeScale()
        {
            targetScale = new Vector3(
                Random.Range(0.5f, 5),
                Random.Range(0.5f, 5),
                Random.Range(0.5f, 5));
        }
    }
}