using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    public abstract class SkillData : ScriptableObject
    {
        public bool Enabled;
        public string Label;
        public string Description;
        public string Icon;
        public float ManaCost;
        public float CastTime;
        public float CooldownTime;
        public float Range;
    }
}
