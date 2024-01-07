using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;

    private NavMeshAgent _agent;
    private Camera _cam;

    // Start is called before the first frame update
    private void Start()
    {
        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                _agent.destination = hitInfo.point;
            }
        }
    }
}
