using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Header("Zoom")]
    [SerializeField] private float _currentZoom = 25.0f;
    [SerializeField] private float _zoomSpeed = 0.0f;
    [Space][SerializeField] private float _minZoom = 0.0f;
    [SerializeField] private float _maxZoom = 0.0f;

    [Header("Rotation")]
    [SerializeField] private float _rotationTime = 0.0f;
    [Space][SerializeField] private float _rotationHSpeed = 0.0f;
    [SerializeField] private float _rotationVSpeed = 0.0f;
    [Space][SerializeField] private float _minVertAngle = 0.0f;
    [SerializeField] private float _maxVertAngle = 0.0f;

    private Vector3 _localRotation;

    private InputSystem _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void LateUpdate()
    {
        _currentZoom -= _inputActions.Camera.Zoom.ReadValue<float>() * _zoomSpeed;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);

        if (_inputActions.Camera.EnableControl.IsPressed())
        {
            Vector2 deltaMouse = _inputActions.Camera.Control.ReadValue<Vector2>().normalized;

            _localRotation.y += deltaMouse.x * _rotationHSpeed;
            _localRotation.x -= deltaMouse.y * _rotationVSpeed;

            _localRotation.x = Mathf.Clamp(_localRotation.x, _minVertAngle, _maxVertAngle);

            Quaternion rotation = Quaternion.Euler(_localRotation.x, _localRotation.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationTime);
        }

        transform.position = _target.position - transform.forward * _currentZoom;
    }
}
