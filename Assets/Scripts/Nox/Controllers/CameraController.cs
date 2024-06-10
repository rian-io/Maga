using Nox.Data;
using Nox.Input;
using Nox.Managers;
using UnityEngine;

namespace Nox.Controllers
{
    public class CameraController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private Transform _target;

        [SerializeField] private CameraData _cameraData;

        #endregion

        #region Instance Atrributes

        private float _currentZoom;

        private Vector3 _localRotation;

        private Transform _transform;
        private Quaternion _rotation;

        #endregion

        #region Unity Events

        private void Start()
        {
            _transform = transform;
            _rotation = _transform.rotation;

            // Starts camera with persisted settings.
            _currentZoom = _cameraData.CurrentZoom;
            _localRotation.x = _cameraData.CurrentVAngle;
            _localRotation.y = _cameraData.CurrentHAngle;
            
            SetCameraRotation(Vector2.zero);
        }

        private void OnEnable()
        {
            EventManager.CameraReset += ResetCameraPosition;
        }

        private void OnDisable()
        {
            EventManager.CameraReset -= ResetCameraPosition;
        }

        private void OnDestroy()
        {
            PersistCameraController();
        }

        private void Update()
        {
            if (InputHandler.IsMoveCameraEnabled())
                SetCameraRotation(InputHandler.GetCameraMovement());

            _currentZoom -= InputHandler.GetZoom() * _cameraData.ZoomSpeed;
            _currentZoom = Mathf.Clamp(_currentZoom, _cameraData.MinZoom, _cameraData.MaxZoom);

            _transform.position = _target.position - _transform.forward * _currentZoom;
        }

        #endregion

        #region Private Methods

        private void SetCameraRotation(Vector2 deltaMouse)
        {
            if (deltaMouse != Vector2.zero)
            {
                _localRotation.y += deltaMouse.x * _cameraData.RotationHSpeed;
                _localRotation.x -= deltaMouse.y * _cameraData.RotationVSpeed;

                _localRotation.x = Mathf.Clamp(_localRotation.x, _cameraData.MinVAngle, _cameraData.MaxVAngle);
            }

            _rotation.eulerAngles = _localRotation;
            _transform.rotation = _rotation;
        }

        private void ResetCameraPosition()
        {
            _currentZoom = _cameraData.DefaultZoom;

            _localRotation.y = _cameraData.DefaultLookAngle.y;
            _localRotation.x = _cameraData.DefaultLookAngle.x;
            
            SetCameraRotation(Vector2.zero);
        }

        private void PersistCameraController()
        {
            _cameraData.CurrentZoom = _currentZoom;

            _cameraData.CurrentHAngle = _localRotation.y;
            _cameraData.CurrentVAngle = _localRotation.x;
        }

        #endregion
    }
}