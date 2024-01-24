using System;
using System.Collections;
using NOX.Maga.Data.Skill;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillController : MonoBehaviour
{
    [SerializeField] private SkillData[] _skills = new SkillData[4];

    private InputSystem _inputSystem;

    private SkillData _selectedSkill;

    private SkillData _activeSkill;

    private bool _casting = false;

    private void Awake()
    {
        _inputSystem = new InputSystem();

        _inputSystem.Player.SelectSkill.performed += ctx => SelectSkill(ctx);
        _inputSystem.Player.ActivateSkill.canceled += _ => UseSkill();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void SelectSkill(InputAction.CallbackContext context)
    {
        try
        {
            var skillIndex = Int32.Parse(context.control.name) - 1;
            _selectedSkill = _skills[skillIndex];

            if (_selectedSkill.Equals(_activeSkill))
            {
                ResetSelection();
                return;
            }

            SkillBehaviour.Select(_selectedSkill);

            Debug.Log($"{_selectedSkill.Label} selected");
        }
        catch (IndexOutOfRangeException) { /* Not print stack trace when skill not equipped in the key pressed. */ }
    }

    private void UseSkill()
    {
        if (_selectedSkill == null || _casting) return;

        _activeSkill = _selectedSkill;
        ResetSelection();

        SkillBehaviour.Activate(_activeSkill);
        StartCoroutine(Cast());
    }

    private void ResetSelection()
    {
        _selectedSkill = null;
    }

    private void ResetActive()
    {
        _activeSkill = null;
    }

    private IEnumerator Cast()
    {
        if (!_activeSkill) { yield break; }

        Debug.Log($"{_activeSkill.Label} cast started");
        _casting = true;

        yield return new WaitForSecondsRealtime(_activeSkill.CastTime);

        Debug.Log($"{_activeSkill.Label} cast finished");

        _casting = false;

        EventManager.RaiseOnSkillCastFinished();

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        Debug.Log($"{_activeSkill.Label} cooldown started");
        yield return new WaitForSecondsRealtime(_activeSkill.CooldownTime);
        Debug.Log($"{_activeSkill.Label} cooldown finished");
        ResetActive();
    }
}
