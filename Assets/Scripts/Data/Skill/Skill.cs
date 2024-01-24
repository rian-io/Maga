using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace NOX.Maga.Data.Skill
{
    public abstract class Skill : ScriptableObject
    {
        public bool Enabled;
        public string Label;
        public string Description;
        public string Icon;
        public float ManaCost;
        public float CastTime;
        public float CooldownTime;

        public virtual void Select()
        { }

        public virtual void Activate()
        {
            EventManager.RaiseOnSkillActivated();
        }
    }
}