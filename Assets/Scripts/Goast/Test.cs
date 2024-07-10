using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    [SerializeField]
    Transform target = null;

    NavMeshAgent agent;
    
    Animator animator;

    enum State
    {
        Idle,
        Walk,
        Attack
    }
    State state;
    void Awaje()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(state== State.Idle)
        {
            UpdateIdle();
        }
        else if(state== State.Walk)
        {
            UpdateWalk();
        }
        else if(state == State.Attack)
        {
            UpdateAttack();
        }
    }
    private void UpdateIdle()
    {
        agent.enabled = false;
        agent.speed = 0;

        if(target != null)
        {
            agent.enabled = true;
            state = State.Walk;
            animator.SetTrigger("Walk");
        }
    }
    private void UpdateWalk()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        agent.speed = 3.5f;
        agent.destination = target.transform.position;

        if (distance <= 8.5)
        {
            state = State.Attack;
            animator.SetTrigger("Attack");
        }

        target = null;
        state = State.Idle;
        animator.SetTrigger("Idle");

    }
    private void UpdateAttack()
    {
        agent.speed = 0;
    }
}
