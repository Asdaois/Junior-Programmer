using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField]
    private Vector3 targetPosition = new(4, 4, 4);

    [SerializeField]
    private Vector3 speed = new(0.2f, 0.4f, 0.1f);

    [SerializeField]
    private Vector3 targetScale = Vector3.one;

    [SerializeField] private float updateScaleTime = 2f;

    private void Start()
    {
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating(nameof(RandomizeScale), updateScaleTime, updateScaleTime);
    }

    private void Update()
    {
        Material material = Renderer.material;
        material.color = new Color(
            0.5f * Mathf.Sin(Time.time + 12f),
            1.0f * Mathf.Sin(Time.time + 42f),
            0.3f * Mathf.Sin(Time.time + 35f),
            0.4f * Mathf.Sin(Time.time + 62f));

        transform.position = new(
                Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * speed.x),
                Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * speed.y),
                Mathf.Lerp(transform.position.z, targetPosition.z, Time.deltaTime * speed.z)
                );

        transform.Rotate(10.0f * Time.deltaTime, 0.2f * Time.deltaTime, 2.0f * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(targetPosition.x) - 0.1)
        {
            targetPosition.x *= -1;
        }
        if (Mathf.Abs(transform.position.y) > Mathf.Abs(targetPosition.y) - 0.1)
        {
            targetPosition.y *= -1;
        }
        if (Mathf.Abs(transform.position.z) > Mathf.Abs(targetPosition.z) - 0.1)
        {
            targetPosition.z *= -1;
        }
        Debug.Log(targetPosition);

        transform.localScale = new(
                Mathf.Lerp(transform.localScale.x, targetScale.x, Time.deltaTime * updateScaleTime),
                Mathf.Lerp(transform.localScale.y, targetScale.x, Time.deltaTime * updateScaleTime),
                Mathf.Lerp(transform.localScale.z, targetScale.x, Time.deltaTime * updateScaleTime));
    }

    private void RandomizeScale()
    {
        targetScale = new(
            Random.Range(0.5f, 5),
            Random.Range(0.5f, 5),
            Random.Range(0.5f, 5));
    }
}