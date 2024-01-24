using UnityEngine;

namespace NOX.Maga.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public float Speed;

        [Header("Distances")]
        public float NormalDistance;
        public float InteractDistance;
        public float AttackDistance;
        public float SkillDistance;

    }
}
