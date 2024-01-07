using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        var randomOffset = Random.insideUnitSphere * 0.5f;
        randomOffset.y = 0;

        _agent.speed = _speed;
        _agent.destination = point + randomOffset;
    }
}
