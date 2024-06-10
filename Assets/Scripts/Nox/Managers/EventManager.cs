using System;
using UnityEngine;

namespace Nox.Managers
{
    public static class EventManager
    {
        #region Action
        public static event Action<RaycastHit> PlayerAct;
        public static void OnPlayerAct(RaycastHit hitInfo) => PlayerAct?.Invoke(hitInfo);
        #endregion 

        #region Camera
        public static event Action CameraReset;
        public static void OnCameraReset() => CameraReset?.Invoke();
        #endregion

        #region Skills
        public static event Action<int> SkillSelect;
        public static void OnSkillSelect(int skillIndex) => SkillSelect?.Invoke(skillIndex);
        #endregion
    }

}
