using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem();

    }

    private void OnEnable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.SelectSkill.performed += ctx => SelectSkill(ctx);
        _inputSystem.Player.ActivateSkill.canceled += _ => UseSkill();
    }

    private void OnDisable()
    {
        _inputSystem.Player.SelectSkill.performed -= ctx => SelectSkill(ctx);
        _inputSystem.Player.ActivateSkill.canceled -= _ => UseSkill();
        _inputSystem.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inputSystem.Player.Move.IsPressed())
        {
            EventManager.RaiseOnAction(GetHitInfo());
        }
    }

    private void SelectSkill(InputAction.CallbackContext context)
    {
        EventManager.RaiseOnSkillSelect(Int32.Parse(context.control.name) - 1);
    }

    private void UseSkill()
    {
        EventManager.RaiseOnUseSkill(GetHitInfo());
    }

    private RaycastHit GetHitInfo()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
        {
            return hitInfo;
        }

        throw new Exception();
    }
}
