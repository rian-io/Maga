using NOX.Maga.Data;
using UnityEngine;
using UnityEngine.AI;

namespace NOX.Maga.Interactions
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        [SerializeField] private LayerMask _movementMask;

        private NavMeshAgent _navAgent;
        private InputSystem _inputActions;

        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _navAgent.speed = _playerData.Speed;

            _inputActions = new InputSystem();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_inputActions.Player.Move.IsPressed())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo)
                    && hitInfo.transform.CompareTag("Ground"))
                {
                    _navAgent.destination = hitInfo.point;
                }
            }
        }
    }
}
