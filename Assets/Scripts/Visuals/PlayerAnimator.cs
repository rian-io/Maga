using UnityEngine;
using UnityEngine.AI;


public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _animator.SetBool("walking", !_agent.velocity.Equals(Vector3.zero));
    }
}
