using UnityEngine;
using UnityEngine.UIElements;

public class SphereSpawmer : MonoBehaviour
{
    [SerializeField] private GameObject sphereObject;
    [SerializeField] private GameObject arrowIndicator;
    private float _minAngle = -50;
    private float _maxAngle = 50;
    private float _currentAngle;
    private float _originalFactor = 30;
    private float _speedFactor = 1f;
    private int _direction = 1;

    // Update is called once per frame
    private void Update()
    {
        _currentAngle += _originalFactor * _speedFactor * _direction * Time.deltaTime;

        if (_direction == 1 && _currentAngle > _maxAngle)
        {
            _direction = -1;
        }

        if (_direction == -1 && _currentAngle < _minAngle)
        {
            _direction = 1;
        }

        arrowIndicator.transform.eulerAngles = new(_currentAngle, 0, 0);

        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            var sphere = Instantiate(sphereObject);
            sphere.transform.position = arrowIndicator.transform.position;

            var sphereRB = sphere.GetComponent<Rigidbody>();

            var forze = 10;
            var angle = (90 + _currentAngle) * Mathf.Deg2Rad;
            var forzeX = -Mathf.Cos(angle);
            var forzeY = Mathf.Sin(angle);

            sphereRB.AddForce(new Vector3(0, forzeY * forze, forzeX * forze), ForceMode.Impulse);
        }
    }
}