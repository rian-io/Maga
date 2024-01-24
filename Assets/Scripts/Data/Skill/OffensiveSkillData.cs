using UnityEditor.Recorder.Input;
using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill/OffensiveSkill")]
    public class OffensiveSkillData : Skill
    {
        public float Damage;

        public override void Select()
        {
            base.Select();
            EventManager.RaiseOnSkillSelected();
            EventManager.RaiseOnSkillDisableMovement();
        }

        public override void Activate()
        {
            base.Activate();
            EventManager.RaiseOnSkillEnableMovement();
        }
    }
}
