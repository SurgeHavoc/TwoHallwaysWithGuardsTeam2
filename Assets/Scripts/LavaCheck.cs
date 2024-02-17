using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LavaCheck : MonoBehaviour
{
    private NavMeshAgent parentNavMeshAgent;

    void Start()
    {
        parentNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvisibleWall"))
        {
            parentNavMeshAgent.enabled = false;
        }
    }
}
