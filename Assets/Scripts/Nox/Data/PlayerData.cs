using UnityEngine;

namespace Nox.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Controller/Player")]
    public class PlayerData : ScriptableObject
    {
        [Header("Default")]
        public float Speed;
    }
}
