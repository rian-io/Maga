using Nox.Data;
using Nox.Managers;
using UnityEngine;

namespace Nox.Controllers
{
    public class SkillController : MonoBehaviour
    {
        [SerializeField] private SkillData[] _skills = new SkillData[4];

        private SkillData _selectedSkill;
        
        private void OnEnable()
        {
            EventManager.SkillSelect += SelectSkill;
        }

        private void OnDisable()
        {
            EventManager.SkillSelect -= SelectSkill;
        }
        
        public void SelectSkill(int atPosition)
        {
            _selectedSkill = _skills[atPosition];
            Debug.Log("Skill selecionada" + _selectedSkill.Label);
        }
    }
}
