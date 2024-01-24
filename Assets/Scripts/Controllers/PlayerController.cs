using System;
using System.Runtime.CompilerServices;
using NOX.Maga.Data;
using UnityEngine;
using UnityEngine.AI;

namespace NOX.Maga.Interactions
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private NavMeshAgent _navAgent;

        private bool _canMove = true;

        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _navAgent.speed = _playerData.Speed;
        }

        private void Start()
        {
            EventManager.OnAction += hitInfo => Move(hitInfo);
            EventManager.OnSkillSelected += DisableMovement;
            EventManager.OnSkillCastFinished += EnableMovement;
            EventManager.OnSkillActivated += StopMoveToCast;
        }

        private void OnDestroy()
        {
            EventManager.OnAction -= hitInfo => Move(hitInfo);
            EventManager.OnSkillSelected -= DisableMovement;
            EventManager.OnSkillCastFinished -= EnableMovement;
            EventManager.OnSkillActivated -= StopMoveToCast;
        }

        private void Move(RaycastHit hitInfo)
        {
            if (_canMove && !hitInfo.transform.CompareTag("Player"))
            {
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    _navAgent.stoppingDistance = _playerData.SkillDistance;
                }
                else
                {
                    _navAgent.stoppingDistance = _playerData.NormalDistance;
                }
                _navAgent.destination = hitInfo.point;
            }
        }

        private void StopMoveToCast()
        {
            _navAgent.ResetPath();

            DisableMovement();
        }

        private void EnableMovement()
        {
            _canMove = true;
        }

        private void DisableMovement()
        {
            _canMove = false;
        }
    }
}
