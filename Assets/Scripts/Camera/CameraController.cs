using NOX.Maga.Data;
using UnityEngine;

namespace NOX.Maga.Interactions
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private CameraData _cameraData;

        private float _currentZoom = 25.0f;

        private Vector3 _localRotation;

        private InputSystem _inputSystem;

        private void Awake()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Camera.ResetCamera.performed += ctx => ResetCameraPosition();
        }

        private void Start()
        {
            _currentZoom = _cameraData.CurrentZoom;
            _localRotation.x = _cameraData.CurrentVAngle;
            _localRotation.y = _cameraData.CurrentHAngle;

            // Starts camera with persisted settings.
            SetCameraRotation(Vector2.zero);
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Disable();
        }

        private void OnDestroy()
        {
            PersistCameraController();

            _inputSystem.Camera.ResetCamera.performed -= ctx => ResetCameraPosition();
        }

        private void LateUpdate()
        {
            _currentZoom -= _inputSystem.Camera.Zoom.ReadValue<float>() * _cameraData.ZoomSpeed;
            _currentZoom = Mathf.Clamp(_currentZoom, _cameraData.MinZoom, _cameraData.MaxZoom);

            if (_inputSystem.Camera.EnableControl.IsPressed())
            {
                Vector2 deltaMouse = _inputSystem.Camera.Control.ReadValue<Vector2>().normalized;
                SetCameraRotation(deltaMouse);
            }

            transform.position = _target.position - transform.forward * _currentZoom;
        }

        private void SetCameraRotation(Vector2 deltaMouse)
        {
            if (deltaMouse != Vector2.zero)
            {
                _localRotation.y += deltaMouse.x * _cameraData.RotationHSpeed;
                _localRotation.x -= deltaMouse.y * _cameraData.RotationVSpeed;

                _localRotation.x = Mathf.Clamp(_localRotation.x, _cameraData.MinVAngle, _cameraData.MaxVAngle);
            }

            Quaternion rotationToDo = Quaternion.Euler(_localRotation.x, _localRotation.y, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToDo, _cameraData.RotationTime);
        }

        private void ResetCameraPosition()
        {
            _currentZoom = 30f;

            _localRotation.y = 0f;
            _localRotation.x = 45f;

            // As the rotation is only enabled when right button is pressed
            // it is necessary to call it explicitly.
            SetCameraRotation(Vector2.zero);
        }

        private void PersistCameraController()
        {
            _cameraData.CurrentZoom = _currentZoom;

            _cameraData.CurrentHAngle = _localRotation.y;
            _cameraData.CurrentVAngle = _localRotation.x;
        }
    }
}
