using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent onTimeOut;
    [SerializeField] private string name;
    [SerializeField] private bool autoStart = false;
    [SerializeField] private bool isOneShot = true;
    [SerializeField, Range(0.0f, 1000f)] private float time = 0f;
    [SerializeField] private bool isActive;

    [SerializeField] private float _currentTime;

    public bool IsActive
    {
        get => isActive;
        set
        {
            isActive = value;
            _currentTime = 0;
        }
    }

    public float Time
    {
        get => time; set
        {
            if (value < 0)
            {
                throw new System.Exception("Numbers in timer can't be negative");
            }

            time = value;
        }
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            _currentTime += UnityEngine.Time.fixedDeltaTime;
        }

        if (_currentTime >= time)
        {
            onTimeOut?.Invoke();
            _currentTime = 0;

            if (isOneShot)
                isActive = false;
        }
    }
}