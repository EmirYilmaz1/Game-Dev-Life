using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerMovementHandler : MonoBehaviour, ICancel
{
    NavMeshAgent navMeshAgent;
    ActionScheduler actionScheduler;
    void Start()
    {
        actionScheduler = GetComponent<ActionScheduler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
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
    }

    
    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }

    // its for action Schedueler
    public void Cancel()
    {
        Stop();
    }
}
