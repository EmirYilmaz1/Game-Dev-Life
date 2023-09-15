using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerMovementHandler : MonoBehaviour, ICancel
{
    Animator animator;
    NavMeshAgent navMeshAgent;
    ActionScheduler actionScheduler;
    void Start()
    {
        animator = GetComponent<Animator>();
        actionScheduler = GetComponent<ActionScheduler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
{
    if (!navMeshAgent.pathPending && !navMeshAgent.isStopped)
    {
        if (navMeshAgent.remainingDistance-.50f <= navMeshAgent.stoppingDistance)
        {
            Stop();
        }
    }
}

    // if player wants to move this method will call
    public void MoveAction(Vector3 targetTransform)
    {
        actionScheduler.StartAction(this);
        Mover(targetTransform);
    }

    //if player wants to go a object this method will call
    public void Mover(Vector3 targetTransform)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(targetTransform);
        animator.SetBool("isWalking", true);
    }

    
    public void Stop()
    {
        animator.SetBool("isWalking",false);
        navMeshAgent.isStopped = true;
    }

    // its for action Schedueler
    public void Cancel()
    {
        Stop();
    }
}
