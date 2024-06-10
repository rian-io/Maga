using Nox.Data;
using Nox.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Nox.Controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        #region Serialized
        [SerializeField] private PlayerData playerData;
        #endregion

        #region Instance Attribute
        private NavMeshAgent _navAgent;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _navAgent.speed = playerData.Speed;
        }

        private void OnEnable()
        {
            EventManager.PlayerAct += PlayerAct;
        }

        private void OnDisable()
        {
            EventManager.PlayerAct -= PlayerAct;
        }
        #endregion

        #region Private Methods
        private void PlayerAct(RaycastHit hitInfo)
        {
            if (hitInfo.transform.CompareTag("Player")) return;

            _navAgent.destination = hitInfo.point;
        }

        private void StopMoveToCast()
        {
            _navAgent.ResetPath();
        }
        #endregion
    }
}
