using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill/DefensiveSkill")]
    public class DefensiveSkillData : SkillData, IAreaTarget
    {
        public float Life;
    }
}
