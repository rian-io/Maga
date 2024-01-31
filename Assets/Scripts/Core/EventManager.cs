using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    #region Inputs
    public static event Action<RaycastHit> OnAction;
    public static void RaiseOnAction(RaycastHit hitInfo) => OnAction?.Invoke(hitInfo);
    #endregion

    #region Skills
    public static event Action<int> OnSkillSelect;
    public static void RaiseOnSkillSelect(int skillIndex) => OnSkillSelect?.Invoke(skillIndex);

    public static event Action OnSkillSelected;
    public static void RaiseOnSkillSelected() => OnSkillSelected?.Invoke();

    public static event Action<RaycastHit> OnUseSkill;
    public static void RaiseOnUseSkill(RaycastHit hitInfo) => OnUseSkill?.Invoke(hitInfo);

    public static event Action OnSkillActivated;
    public static void RaiseOnSkillActivated() => OnSkillActivated?.Invoke();

    public static event Action OnSkillCastFinished;
    public static void RaiseOnSkillCastFinished() => OnSkillCastFinished?.Invoke();
    #endregion
}
