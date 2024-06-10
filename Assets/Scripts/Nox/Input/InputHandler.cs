using Nox.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nox.Input
{
    public class InputHandler : Singleton<InputHandler>
    {
        #region References
        private InputSystem _inputSystem;
        private Camera _cam;
        #endregion

        #region Unity Events
        private new void Awake()
        {
            base.Awake();
            _inputSystem = new InputSystem();
            _cam = Camera.main;
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
            _inputSystem.Player.SelectSkill.performed += SelectSkill;
            _inputSystem.Camera.ResetCamera.performed += ResetCamera;
        }

        private void OnDisable()
        {
            _inputSystem.Player.SelectSkill.performed -= SelectSkill;
            _inputSystem.Camera.ResetCamera.performed -= ResetCamera;
            _inputSystem.Disable();
        }

        private void Update()
        {
            if (_inputSystem.Player.Action.IsPressed())
            {
                var ray = _cam.ScreenPointToRay(UnityEngine.Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
                    EventManager.OnPlayerAct(hitInfo);
            }
        }
        #endregion

        #region Skill
        private void SelectSkill(InputAction.CallbackContext context)
        {
            EventManager.OnSkillSelect(int.Parse(context.control.name) - 1);
        }
        #endregion

        #region Camera
        public static float GetZoom()
        {
            return Instance._inputSystem.Camera.Zoom.ReadValue<float>();
        }

        public static bool IsMoveCameraEnabled()
        {
            return Instance._inputSystem.Camera.EnableControl.IsPressed();
        }

        public static Vector2 GetCameraMovement()
        {
            return Instance._inputSystem.Camera.Control.ReadValue<Vector2>();
        }

        private void ResetCamera(InputAction.CallbackContext _)
        {
            EventManager.OnCameraReset();
        }
        #endregion
    }
}
