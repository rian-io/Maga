using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill/DefensiveSkill")]
    public class DefensiveSkillData : Skill
    {
        public float Life;

        public float Range;

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
