using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Zoom")]
    [SerializeField, Range(10, 45)] private float _currentZoom = 25.0f;
    [SerializeField] private float _zoomSpeed = 0.0f;
    [SerializeField] private float _minZoom = 0.0f;
    [SerializeField] private float _maxZoom = 0.0f;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed = 0.0f;
    [SerializeField] private float _minVertAngle = 0.0f;
    [SerializeField] private float _maxVertAngle = 0.0f;

    private Vector3 _localRotation;

    private void LateUpdate()
    {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);

        if (Input.GetMouseButton(1))
        {
            _localRotation.y += Input.GetAxis("Mouse X") * _rotationSpeed;
            _localRotation.x -= Input.GetAxis("Mouse Y") * _rotationSpeed;

            _localRotation.x = Mathf.Clamp(_localRotation.x, _minVertAngle, _maxVertAngle);

            Quaternion qt = Quaternion.Euler(_localRotation.x, _localRotation.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * 10);
        }

        transform.position = _target.position - transform.forward * _currentZoom;
    }
}
