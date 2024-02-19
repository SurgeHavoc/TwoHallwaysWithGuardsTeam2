using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LavaCheck : MonoBehaviour
{
    private NavMeshAgent parentNavMeshAgent;
    private Rigidbody parentrb;
    private Animator parentAnim;

    Vector3 customGravityDirection = new Vector3(0, -1, 0);
    float customGravityStrength = 4000f;

    void Start()
    {
        parentNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
        parentrb = transform.parent.GetComponent<Rigidbody>();
        parentAnim = transform.parent.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvisibleWall"))
        {
            parentNavMeshAgent.enabled = false;
            parentrb.AddForce(customGravityDirection * customGravityStrength, ForceMode.Acceleration);
            parentAnim.enabled = false;
        }
    }
}
