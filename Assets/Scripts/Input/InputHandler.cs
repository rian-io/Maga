using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
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

    // Update is called once per frame
    private void Update()
    {
        if (_inputActions.Player.Move.IsPressed())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                EventManager.RaiseOnAction(hitInfo);
            }
        }
    }
}
