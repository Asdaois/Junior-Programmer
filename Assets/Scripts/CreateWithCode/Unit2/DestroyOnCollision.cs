using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public delegate void DestroyEvent();

    public event DestroyEvent OnDestroy;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);

        OnDestroy?.Invoke();
    }
}