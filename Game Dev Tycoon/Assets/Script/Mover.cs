using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, ICancel
{
    NavMeshAgent navMeshAgent;
    Ray ray;
    RaycastHit raycastHit;
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       
    }

    public void StartMove(Vector3 raycastHit)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(raycastHit);
    }

    public void StartActionMove(Vector3 raycastHit)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        StartMove(raycastHit);
    }

    public void Cancel()
    {
        navMeshAgent.isStopped = true;
    }
}
