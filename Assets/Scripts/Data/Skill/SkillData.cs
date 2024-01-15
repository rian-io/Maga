using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    public class SkillData : ScriptableObject
    {
        public string label;
        public string description;
        public string icon;
        public float manaCost;
        public float castTime;
        public float cooldown;

        private void Activate()
        {

        }
    }
}