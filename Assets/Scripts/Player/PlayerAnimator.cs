using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerAnimator : MonoBehaviour
{
    private float _dampTime = .0f;

    private Animator _animator;

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float locomotionSpeed = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("locomotionSpeed", locomotionSpeed, _dampTime, Time.deltaTime);
    }
}
