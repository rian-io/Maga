using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill/OffensiveSkill")]
    public class OffensiveSkillData : SkillData, IEnemyTarget
    {
        public float Damage;
    }
}
