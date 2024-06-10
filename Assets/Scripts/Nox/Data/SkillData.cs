using UnityEngine;

namespace Nox.Data
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill")]
    public class SkillData : ScriptableObject
    {
        public string Label;
        public string Description;
        public string Icon;

        public int Type;
        public int Property;
        
        public float ManaCost;
        public float CastTime;
        [Tooltip("Minimun distance to target")]
        public float Range;

        [Tooltip("Time to materialize skill and animations")]
        public float CastDelay;
        [Tooltip("Duration of skill's animation")]
        public float Duration;
        
        public float CooldownTime;
    }
}
