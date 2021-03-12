using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroineMover : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void SetNavDestination(Vector3 destination)
    {
        _navMeshAgent?.SetDestination(destination);
    }
}
