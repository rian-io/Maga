using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHolder : MonoBehaviour
{
    [SerializeField] private String[] _skills = new string[4];

    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void UseSkill()
    {

    }
}
